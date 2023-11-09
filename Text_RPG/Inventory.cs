using System;
using System.Collections.Generic;
using System.Linq;
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
        public Inventory()
        {
            maxSlot = 30;
            inventorys = new List<List<Item>>();
            inventorys.Capacity = (int)Item.ItemTypes.End;
            inventorys.Add(new List<Item>());
            inventorys.Add(new List<Item>());

            for (int i = 0; i < inventorys.Count; i++)
                inventorys[i].Capacity = maxSlot;

          
        }
        public void AddItem(Item item)
        {   
            //인벤토리에 아이템 추가
            if (item is Consumption)
            {
                Item consumption = FindPortion(item);
                if (consumption != null)
                {
                    ((Consumption)consumption).ItemCount++;
                    item = null;
                    return;
                }
            }
            inventorys[(int)item.ItemType].Add(item);
            return;
        }
        public Item FindPortion(Item item)
        {
            //인벤토리에 아이템이 존재하는지 확인
            if (item.ItemType == Item.ItemTypes.Consumption)
            {
                var itemTemp = inventorys[(int)Item.ItemTypes.Consumption];

                for (int i = 0; i < itemTemp.Count; i++)
                {
                    if (item.ItemName == itemTemp[i].ItemName)
                    {
                        return itemTemp[i];
                    }
                }
            }
            return null;
        }
        public List<Item> GetInventory(Item.ItemTypes type)
        {
            //장비 리스트 소비리스트 선택해서 리스트 반환
            return inventorys[(int)type];           
        }

    }
}
