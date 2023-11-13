using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity;

namespace Text_RPG.Battle
{
    internal class AttackCommand : Command
    {
        public Character character;
        public Monster target;
        public AttackCommand(Character character, Monster target)
        {
            this.character = character;
            this.target = target;
            priority = 4;
        }

        public override void Execute()
        {
            character.Attack(target);
        }
    }
}
