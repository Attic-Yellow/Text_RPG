using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;

namespace Text_RPG.Skill
{
    public abstract class SelfSkill : Skill
    {
        public Entity.Entity target;
        public SelfSkill(Entity.Entity owner) : base(owner)
        {
        }

        public override abstract void Execute();

        public override void SetTarget()
        {
            this.target = owner;       
        }
    }
}
