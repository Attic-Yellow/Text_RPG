using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;
using Text_RPG.Entity.Monster;
using Text_RPG.Items;
using Text_RPG.Items.Consumptions;

namespace Text_RPG.Battle
{
    /// <summary>
    /// 사용 아이템, 유저
    /// </summary>
    public class ItemUseCommand : Command
    {
        Consumption item;
        Character user;
        public ItemUseCommand(Consumption item, Character user)
        {
            this.user = user;
            this.item = item;
            priority = 1;
        }

        public override void Execute()
        {
            item.UseItem();
        }
    }
}
