using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Skill.Interface;

namespace Text_RPG.Skill.Common.Monster
{
    public class GroupAttack : MultiSkill
    {
        public GroupAttack(Entity.Entity owner) : base(owner)
        {
        }

        public override void Execute()
        {
        }
    }
}
