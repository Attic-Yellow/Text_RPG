using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Skill;

namespace Text_RPG.Entity.Character
{
    public class Character : Entity
    {
        public Data.PlayerClass playerClass { get; set; }
        public int level { get; set; }
        public int maxHp { get; set; }
        public int currentHp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public double critRate { get; set; }
        public double critPer { get; set; }

        public List<Skill.Skill> skillList = new List<Skill.Skill>();

        public virtual void LevelUp()
        {
            level += 1;
            Console.WriteLine("Level Up!");
            Console.WriteLine("TESTESTESTS");

        }

        public void StatUp(Items.Item item)
        {
            Console.WriteLine("Test@@");
            if (item is Items.Equipments.Weapons.Weapon)
            {
                // this.attack += item.attack
            }
            
        }
    }
}