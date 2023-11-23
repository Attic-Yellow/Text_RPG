using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;
using Text_RPG.Skill.Interface;

namespace Text_RPG.Skill.Common
{
    public class HardAttack : SingleSkill
    {
        public HardAttack(Entity.Entity owner) : base(owner)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void SetTarget()
        {
            if (owner is Character)
            {
                target = owner.targetList[1][0];
            }
            else
            {
                Random random = new Random();
                int rndTarget;
                while (true)
                {
                    rndTarget = random.Next(0, 3);
                    if (owner.targetList[0][rndTarget].Alive)
                        break;
                }
                target = owner.targetList[0][rndTarget];
            }
        }
    }
}
