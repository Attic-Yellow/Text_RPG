using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Skill;

namespace Text_RPG.Entity.Character
{
    public abstract class Character : Entity
    {
        public int level { get; set; }
        public int maxHp { get; set; }
        public int currentHp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int critRate { get; set; }
        public int critPer { get; set; }

        public List<Skill.Skill> skillList = new List<Skill.Skill>();

        public void LevelUp()
        {
            level += 1;
            StatUp();
        }

        public abstract void StatUp();
    }
}