﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;

namespace Text_RPG.Skill
{
    internal abstract class MultiSkill : Skill
    {
        List<Entity.Entity> targetList;

        protected MultiSkill(Entity.Entity owner, List<List<Entity.Entity>> targetList) : base(owner, targetList)
        {
        }

        public override abstract void Execute();
    

        public override void SetTarget()
        {
            this.targetList = base.targetList[1];
        }
    }
}
