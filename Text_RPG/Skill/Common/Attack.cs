﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;
using Text_RPG.Skill.Interface;

namespace Text_RPG.Skill.Common
{
    public class Attack : Skill, ITargetOne, ITargetMonster
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
