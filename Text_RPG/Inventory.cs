using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items;
using Text_RPG.Items.Consumptions;
using Text_RPG.Items.Equipments;

namespace Text_RPG
{
    internal class Inventory
    {
        private List<List<Item>> inventories;
        private int maxSlot;
        private int gold;
        public Inventory()
        {
            gold = 0;
            maxSlot = 30;
            inventories = new List<List<Item>>();
            inventories.Capacity = (int)Item.ItemTypes.End;
            inventories.Add(new List<Item>());
            inventories.Add(new List<Item>());

            for (int i = 0; i < inventories.Count; i++)
                inventories[i].Capacity = maxSlot;
                      
        }
        public int Gold { get { return gold; } set { gold = value; } }
        public List<Item> GetInventoryItems(Item.ItemTypes type)
        {
            return inventories[(int)type];
        }

        private void RemoveItem(Item.ItemTypes type,int index)
        {
            if (index < 0 || index >= inventories[(int)type].Count)
                return;

            inventories[(int)type].RemoveAt(index);
        }

        public void AddItem(Item item)
        {
            if (item == null)
                return;

            if(item is Equipment)
            {
                inventories[(int)Item.ItemTypes.Equipment].Add(item);
            }
            else
            {
                foreach(Item itemTemp in inventories[(int)(Item.ItemTypes.Consumption)])
                {
                    if(itemTemp.ItemName == item.ItemName)
                    {
                        ((Consumption)itemTemp).ItemCount += ((Consumption)itemTemp).ItemCount;
                        return;
                    }
                }
                inventories[(int)Item.ItemTypes.Consumption].Add(item);
            }              
        }
        public void SellItem(Item.ItemTypes type,int index)
        {
            if(type == Item.ItemTypes.Equipment)
            {
                gold += inventories[(int)type][index].SellGold;
            }
            else
            {
                gold += (inventories[(int)type][index].SellGold * ((Consumption)inventories[(int)type][index]).ItemCount);
            }

            RemoveItem(type, index);
        }

    

    }
}
