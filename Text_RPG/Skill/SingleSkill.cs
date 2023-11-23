using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Skill
{
    public abstract class SingleSkill : Skill
    {
        public Entity.Entity target;
        protected SingleSkill(Entity.Entity owner) : base(owner)
        {
        }


    }
}
