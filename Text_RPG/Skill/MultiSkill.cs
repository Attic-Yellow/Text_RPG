using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;

namespace Text_RPG.Skill
{
    public abstract class MultiSkill : Skill
    {
        public List<Entity.Entity> targets;

        protected MultiSkill(Entity.Entity owner) : base(owner)
        {
        }

    

        public override void SetTarget()
        {
            targets = owner.targetList[0];
        }
    }
}
