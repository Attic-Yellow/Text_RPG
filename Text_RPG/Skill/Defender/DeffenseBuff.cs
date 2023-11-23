using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Skill.Defender
{
    public class DeffenseBuff : SelfSkill
    {
        public DeffenseBuff(Entity.Entity owner, List<List<Entity.Entity>> targetList) : base(owner, targetList)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
