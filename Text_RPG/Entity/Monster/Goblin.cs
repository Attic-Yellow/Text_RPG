using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Entity.Monster
{
    public class Goblin: Monster
    {
        public Goblin()
        {
            // stats
            skillList.Add(new Skill.Goblin.StealMoney(this));
        }

    }
}
