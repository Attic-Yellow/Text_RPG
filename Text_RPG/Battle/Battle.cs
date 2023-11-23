using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity;
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
    public class Battle
    {
        public Player player;  // Player로 변할 수도 있음.
        public Monster monster;
        public List<List<Entity.Entity>> targetList = new List<List<Entity.Entity>>();
        public int turn;
        public CommandManager commandManager = new CommandManager();
        bool OnBattle;  // charcter 전멸 혹은 monster 죽음
        public Random random = new Random();
        int alive = 3;

        public Battle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
            List<Entity.Entity> characterList = new List<Entity.Entity>();
            characterList.Add(player.characters[0]);
            characterList.Add(player.characters[1]);
            characterList.Add(player.characters[2]);
            List<Entity.Entity> monsterList = new List<Entity.Entity>();
            monsterList.Add(monster);
            player.characters[0].targetList = this.targetList;
            player.characters[1].targetList = this.targetList;
            player.characters[2].targetList = this.targetList;
            monster.targetList = this.targetList;
            turn = 0;
            bool OnBattle = true;
        }

   
        public void StartBattle()
        {
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
            List<Skill.SingleSkill> usableSkills = new List<Skill.SingleSkill>();
            List<Skill.SingleSkill> monsterPicks = new List<Skill.SingleSkill>();
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
                monsterPicks[0].SetTarget();
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
                        selected.skillList[0].SetTarget();
                        commandManager.AddCommand(new AttackCommand(selected), Array.IndexOf(player.characters, selected));
                        break;

                    // 명령 선택 : 스킬 "S" -> "QWERT"
                    case "s":
                    case "S":
                        switch (Input())
                        {
                            case "q":
                            case "Q":
                                selected.skillList[1].SetTarget();
                                commandManager.AddCommand(new SkillCommand(selected,selected.skillList[1]), Array.IndexOf(player.characters, selected));
                                break;
                            case "w":
                            case "W":
                                selected.skillList[2].SetTarget();
                                commandManager.AddCommand(new SkillCommand(selected, selected.skillList[2]), Array.IndexOf(player.characters, selected));
                                break;
                            case "e":
                            case "E":
                                selected.skillList[3].SetTarget();
                                commandManager.AddCommand(new SkillCommand(selected, selected.skillList[3]), Array.IndexOf(player.characters, selected));
                                break;
                            case "r":
                            case "R":
                                selected.skillList[4].SetTarget();
                                commandManager.AddCommand(new SkillCommand(selected, selected.skillList[4]), Array.IndexOf(player.characters, selected));
                                break;
                            case "t":
                            case "T":
                                selected.skillList[5].SetTarget();
                                commandManager.AddCommand(new SkillCommand(selected, selected.skillList[5]), Array.IndexOf(player.characters, selected));
                                break;
                            case "s":
                            case "S":
                                break;
                        }
                        break;

                    // 명령 선택 : 인벤토리 "I"
                    case "i":
                    case "I":
                        break;

                    // 명령 선택 : 대기 "H"
                    case "h":
                    case "H":
                        commandManager.AddCommand(new NullCommand(selected), Array.IndexOf(player.characters, selected));
                        break;

                    // 명령 선택 : 도망가기 "P" 
                    // 가능하면 ESC로 하고 싶음
                    case "p":
                    case "P":
                        break;

                    // 명령 선택 : 확정 "F" 
                    // 가능하면 SPACE로 하고 싶음
                    case "f":
                    case "F":
                        break;
                    default:
                        continue;
                }

            }
        }

        public string Input()
        {
            return Console.ReadLine();
        }
        public void CommandSort()
        {
            commandManager.SortCommands();
        }

        public void CommandExecute()
        {
            commandManager.ExecuteCommand();
        }

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
