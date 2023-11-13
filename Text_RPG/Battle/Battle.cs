using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Battle.NOTE;
using Text_RPG.Entity.Character;
using Text_RPG.Entity.Monster;

namespace Text_RPG.Battle
{
    public class Battle<T> where T : Monster
    {
        public Character[] characters;  // Player로 변할 수도 있음.
        public T monster;
        public int turn;
        public CommandManager commandManager = new CommandManager();
        bool OnBattle;
        public Random random = new Random();
        public Battle(Character[] characters, T monster)
        {
            this.characters = characters;
            this.monster = monster;
            turn = 0;
            bool OnBattle = true;
        }

        public void StartTurn()
        {
            turn += 1;
        }
        public void MonsterCommandSelect()
        {
            List<Skill> usableSkills = new List<Skill>();
            List<Skill> monsterPicks = new List<Skill>();
            for (int i = 0; i < 5; i++)
            {
                if (monster.skills[i].cooldown != 0)
                {
                    usableSkills.Add(monster.skills[i]);
                }
            }
            int RandomValue = random.Next(0, usableSkills.Count());
            monsterPicks.Add(usableSkills[RandomValue]);
            usableSkills.RemoveAt(RandomValue);
            RandomValue = random.Next(0, usableSkills.Count());
            monsterPicks.Add(usableSkills[RandomValue]);
            RandomValue = random.Next(0, 101);
            Console.WriteLine("{0}, {1}%, {2}, {3}%", monsterPicks[0], RandomValue, monsterPicks[1], 100 - RandomValue);
            int RandomValue2 = random.Next(0, 101);
            if (RandomValue2 <= RandomValue)
            {
                SkillCommand monsterSkill = new SkillCommand(monster, monsterPicks[0]);
                commandManager.AddCommand(monsterSkill, 0);
            }
            else
            {
                SkillCommand monsterSkill = new SkillCommand(monster, monsterPicks[1]);
            }
        }

        public void PlayerCommandSelect()
        { }

        public void CommandSort()
        {
            commandManager.SortCommands();
        }

        public void CommandExecute()
        { }

        public void ExitTurn()
        {

        }
    }
}
