using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity;
using Text_RPG.Entity.Character;

namespace Text_RPG.Skill
{
    public abstract class PlayerSkill : Skill
    {
        public Player target;
        protected PlayerSkill(Entity.Entity owner) : base(owner)
        {
        }

        public override void SetTarget()
        {
            this.target = ((Character)owner.targetList[0][0]).owner;
        }
    }
}
