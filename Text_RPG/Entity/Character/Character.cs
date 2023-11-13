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
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int CritRate { get; set; }
        public int CritPer { get; set; }

        public List<Skill.Skill> skills = new List<Skill.Skill>();
    }
}
