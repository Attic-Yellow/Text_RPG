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
        public Character character;
        public Monster monster;
        public AttackCommand(Character character, Monster target)
        {
            this.character = character;
            priority = 8;
            this.monster = target;
        }

        public AttackCommand(Monster monster)
        {
            this.monster = monster;
            priority = 8;
        }

        public override void Execute()
        {
            character.skillList[0].Execute();
        }
    }
}
