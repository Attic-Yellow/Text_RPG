using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Skill.Healer
{
    public class Heal : SingleSkill
    {
        public Heal(Entity.Entity owner) : base(owner)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void SetTarget()
        {
            throw new NotImplementedException();
        }
    }
}
