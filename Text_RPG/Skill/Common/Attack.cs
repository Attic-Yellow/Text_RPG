using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;
using Text_RPG.Skill.Interface;

namespace Text_RPG.Skill.Common
{
    public class Attack : SingleSkill
    {
        Entity.Entity target;
        public Attack(Entity.Entity owner) : base(owner)
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
                target = targetList[2][0];
            }
            else
            {
                Random random = new Random();
                int rndTarget;
                while (true)
                {
                    rndTarget = random.Next(0, 3);
                    if (targetList[1][rndTarget].Alive)
                        break;
                }
                target = targetList[1][rndTarget];
            }
        }
    }
}
