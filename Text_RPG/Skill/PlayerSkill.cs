using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity;

namespace Text_RPG.Skill
{
    internal abstract class PlayerSkill : Skill
    {
        Player target;
        protected PlayerSkill(Entity.Entity owner, List<List<Entity.Entity>> targetList) : base(owner, targetList)
        {
        }

        public override void SetTarget()
        {
            this.target = (Player)base.targetList[0][0];
        }
    }
}
