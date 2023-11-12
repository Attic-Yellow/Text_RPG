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
        private List<List<Item>> inventorys;
        private int maxSlot;
        private int gold;
        public Inventory()
        {
            gold = 0;
            maxSlot = 30;
            inventorys = new List<List<Item>>();
            inventorys.Capacity = (int)Item.ItemTypes.End;
            inventorys.Add(new List<Item>());
            inventorys.Add(new List<Item>());

            for (int i = 0; i < inventorys.Count; i++)
                inventorys[i].Capacity = maxSlot;
                      
        }
        public int Gold { get { return gold; } set { gold = value; } }
        public List<Item> GetInventoryItems(Item.ItemTypes type)
        {
            return inventorys[(int)type];
        }

        private void RemoveItem(Item.ItemTypes type,int index)
        {
            if (index < 0 || index >= inventorys[(int)type].Count)
                return;

            inventorys[(int)type].RemoveAt(index);
        }

        public void AddItem(Item item)
        {
            if (item == null)
                return;

            if(item is Equipment)
            {
                inventorys[(int)Item.ItemTypes.Equipment].Add(item);
            }
            else
            {
                foreach(Item itemTemp in inventorys[(int)(Item.ItemTypes.Consumption)])
                {
                    if(itemTemp.ItemName == item.ItemName)
                    {
                        ((Consumption)itemTemp).ItemCount += ((Consumption)itemTemp).ItemCount;
                        return;
                    }
                }
                inventorys[(int)Item.ItemTypes.Consumption].Add(item);
            }              
        }
        public void SellItem(Item.ItemTypes type,int index)
        {
            if(type == Item.ItemTypes.Equipment)
            {
                gold += inventorys[(int)type][index].SellGold;
            }
            else
            {
                gold += (inventorys[(int)type][index].SellGold * ((Consumption)inventorys[(int)type][index]).ItemCount);
            }

            RemoveItem(type, index);
        }

    

    }
}
