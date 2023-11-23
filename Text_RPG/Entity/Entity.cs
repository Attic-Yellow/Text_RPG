using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Entity
{
    public abstract class Entity
    {
        public string Name { get; set; }    // 이름
        public bool Alive { get; set; }

        public List<List<Entity>> targetList;
        public List<Skill.SingleSkill> skillList = new List<Skill.SingleSkill>();

        public void TakeHit(int damage)
        {

        }

        public void TakeHeal(int amount)
        {

        }

    }

}
