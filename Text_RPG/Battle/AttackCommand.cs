using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;
using Text_RPG.Entity.Monster;

namespace Text_RPG.Battle
{
    public class AttackCommand : Command
    {
        Entity.Entity entity;
        public AttackCommand(Entity.Entity entity)
        {
            this.entity = entity;
            priority = 8;
        }


        public override void Execute()
        {
            entity.skillList[0].Execute();           
        }
    }
}
