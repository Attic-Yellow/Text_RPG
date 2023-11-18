﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;
using Text_RPG.Entity.Monster;
using Text_RPG.Skill;
using Text_RPG.Skill.Interface;
using Text_RPG.UI;
using Text_RPG.Util;

namespace Text_RPG.Battle
{
    /// <summary>
    /// 배틀 진행 순서
    /// 1. 몬스터 결정
    /// 2. 배틀 시작
    /// 3. 턴카운트 시작
    /// 4. 몬스터 명령 출력 (A 50%, B 50%)
    /// 5. 플레이어 명령 입력 (1 A, 2 B, 3 C)
    /// 6. 명령 우선순위 결정
    /// 7. 명령 실행
    /// 8. 3번으로 복귀
    /// 9. 몬스터 죽으면 경험치, 골드, 아이템 드랍
    /// 10. 전투 종료
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Battle<T> where T : Monster
    {
        public Player player;  // Player로 변할 수도 있음.
        public T monster;
        public int turn;
        public CommandManager commandManager = new CommandManager();
        bool OnBattle;  // charcter 전멸 혹은 monster 죽음
        public Random random = new Random();
        public Text_RPG.Battle.Battle<T> battle;
        int alive = 3;

        public Battle(Player player, T monster)
        {
            this.player = player;
            this.monster = monster;
            turn = 0;
            bool OnBattle = true;
        }

   
        public void StartBattle(Player player, T monster)
        {
            battle = new Battle<T>(player, monster);
            // 전투창 출력
            while (OnBattle)
            {
                StartTurn();
                MonsterCommandSelect();
                // 몬스터 명령 출력
                PlayerCommandSelect();
                CommandSort();
                CommandExecute();
                ExitTurn();
            }
            StopBattle();
        }
        public void StartTurn()
        {
            turn += 1;
        }
        public void MonsterCommandSelect()
        {
            List<Skill.Skill> usableSkills = new List<Skill.Skill>();
            List<Skill.Skill> monsterPicks = new List<Skill.Skill>();
            SkillCommand monsterSkill;
            for (int i = 0; i < 5; i++)
            {
                if (monster.skillList[i].cooldown != 0)
                {
                    usableSkills.Add(monster.skillList[i]);
                }
            }
            int RandomValue = random.Next(0, usableSkills.Count());
            monsterPicks.Add(usableSkills[RandomValue]);
            usableSkills.RemoveAt(RandomValue);
            RandomValue = random.Next(0, usableSkills.Count());
            monsterPicks.Add(usableSkills[RandomValue]);
            RandomValue = random.Next(0, 101);
            Console.WriteLine("{0}, {1}%, {2}, {3}%", monsterPicks[0].name, RandomValue, monsterPicks[1].name, 100 - RandomValue);
            int RandomValue2 = random.Next(0, 101);
            if (RandomValue2 <= RandomValue)
            {
                monsterPicks.RemoveAt(1);
            }
            else
            {
                monsterPicks.RemoveAt(0);
            }
            if (monsterPicks[0] is ITargetPlayer)
            {
                monsterPicks[0].SetTargetPlayer(player);
            }
            else if (monsterPicks[0] is ITargetOne)
            {
                while (true)
                {
                    int randomtarget = random.Next(0, 3);
                    if (player.characters[randomtarget].Alive)
                    {
                        monsterPicks[0].SetTarget(player.characters[randomtarget]);
                        break;
                    }
                }
            }
            else if (monsterPicks[0] is ITargetSelf)
            {
                monsterPicks[0].SetTarget(monster);
            }
            else if (monsterPicks[0] is ITargetAll)
            {
                monsterPicks[0].SetTargetAll(player.characters);
            }
                commandManager.AddCommand(new SkillCommand(monster, monsterPicks[0]), 3);
        }

        public void CheckPlayerStatus()
        {
            for (int i = 0; i < 3; i++)
            {
                if (player.characters[0].Alive == false)
                {
                    commandManager.AddCommand(new NullCommand(player.characters[i]), i);
                }
                else
                {
                    alive++;
                }
            }
        }
        public void PlayerCommandSelect()
        {
            Character selected = null;
            CheckPlayerStatus();

            // 초기값
            for (int i = 0; i < 3; i++)
            {
                if (player.characters[i].Alive == true)
                {
                    selected = player.characters[i];
                }
                break;
            }

            while (true)
            {
                switch (Input())
                {
                    // 캐릭터 선택
                    case "1":
                        if (player.characters[0].Alive)
                            selected = player.characters[0];
                        break;
                    case "2":
                        if(player.characters[0].Alive)
                            selected = player.characters[1];
                        break;
                    case "3":
                        if (player.characters[0].Alive)
                            selected = player.characters[2];
                        break;

                    // 명령 선택 : 공격 "A"
                    case "a":
                    case "A":
                        commandManager.AddCommand(new AttackCommand(selected,monster), Array.IndexOf(player.characters, selected));
                        break;

                    // 명령 선택 : 스킬 "S" -> "QWERT"
                    case "s":
                    case "S":
                        switch (Input())
                        {
                            case "q":
                            case "Q":

                            case "w":
                            case "W":

                            case "e":
                            case "e":

                            case "r":
                            case "R":

                            case "t":
                            case "T":

                            case "s":
                            case "S":
                        }
                        break;

                    // 명령 선택 : 인벤토리 "I"
                    case "i":
                    case "I":

                    // 명령 선택 : 대기 "H"
                    case "h":
                    case "H":

                    // 명령 선택 : 도망가기 "P" 
                    // 가능하면 ESC로 하고 싶음
                    case "p":
                    case "P":

                    // 명령 선택 : 확정 "F" 
                    // 가능하면 SPACE로 하고 싶음
                    case "f":
                    case "F":
                    
                }

            }
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void SetTarget(Skill.Skill skill, Character executer)
        {
            if (skill is ITargetAll)
            {
                skill.SetTargetAll(player.characters);
            }
            else if (skill is ITargetMonster)
            {
                skill.SetTarget(monster);
            }
            else if (skill is ITargetOne)
            {
                while (true)
                {
                    Character target = ChooseTarget();
                    if (target.Alive)
                    {
                        skill.SetTarget(target);
                        continue;
                    }
                }
            }
            else if (skill is ITargetSelf)
            {
                skill.SetTargetSelf(executer);
            }
            else if (skill is ITargetPlayer)
            { }
        }

        public Character ChooseTarget()
        {
            switch (Input())
            {
                case "1":
                    return player.characters[0];
                    break;
                case "2":
                    return player.characters[1];
                    break;
                case "3":
                    return player.characters[2];
                    break;
                default:
                    return player.characters[0];
            }
        }

        public void CommandSort()
        {
            commandManager.SortCommands();
        }

        public void CommandExecute()
        { }

        public void ExitTurn()
        {

        }

        public void BattleWin()
        {
            // 몬스터 경험치, 몬스터 골드, 몬스터 아이템 드랍
            // 캐릭터 레벨 업, 인벤토리에 입력
        }

        public void BattleLose()
        {
            // 전투패배창 출력
        }

        public void StopBattle()
        {
            // 전투 종료
            // if (전투 승리)
            BattleWin();
            // else (전투 패배)
            BattleLose();
            // 메인메뉴로
        }
    }
}
