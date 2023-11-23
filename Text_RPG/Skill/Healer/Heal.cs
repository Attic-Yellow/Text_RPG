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
            int input;
            while (true)
            {
                string inputStr = Console.ReadLine();
                try
                {
                    input = int.Parse(inputStr);
                }
                catch
                {
                    continue;
                }
                if (owner.targetList[0][input].Alive)
                    break;
                else
                    continue;
            }
            target = owner.targetList[0][input];
        }
    }
}
