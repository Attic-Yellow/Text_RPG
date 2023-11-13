using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items;
using Text_RPG.Items.Consumptions;
using Text_RPG.Items.Equipments;
using Text_RPG.Items.Equipments.Protectives;
using Text_RPG.Items.Equipments.Weapons;

namespace Text_RPG
{
    internal class Shop
    {
        List<List<Item>> shopItems;

        public Shop()
        {
            shopItems = new List<List<Item>>();
            shopItems.Capacity = (int)Item.ItemTypes.End;
            shopItems.Add(new List<Item>());
            shopItems.Add(new List<Item>());
            for (int i = 0; i < 5; i++)
            {
                shopItems[(int)Item.ItemTypes.Equipment].Add(new Weapon(i));
                shopItems[(int)Item.ItemTypes.Equipment].Add(new Hat(i));
                shopItems[(int)Item.ItemTypes.Equipment].Add(new Armor(i));
                shopItems[(int)Item.ItemTypes.Equipment].Add(new Shoes(i));
            }
        }
        public void BuyItem(Inventory inventory, Item.ItemTypes type, int index)
        {
            if (inventory == null)
                return;
            if (index < 0 || index >= shopItems[(int)type].Count)
                return;

            Item item = shopItems[(int)type][index];

            inventory.Gold -= item.BuyGold;
            inventory.AddItem(item.DeepCopy());


        }
    }
}
