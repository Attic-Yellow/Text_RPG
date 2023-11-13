using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity;
using Text_RPG.Items;

namespace Text_RPG.Battle
{
    internal class ItemUseCommand : Command
    {
        Item item;
        Character target;
        public ItemUseCommand(Item item, Character target)
        {
            this.target = target;
            this.item = item;
            priority = 5;
        }

        public override void Execute()
        {
            item.Execute();
        }
    }
}
