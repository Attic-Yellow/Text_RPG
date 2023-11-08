using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items;

namespace Text_RPG
{
    internal class Inventory
    {
        public Inventory()
        {
            items = new Item[50];

        }
        public void AddItem(Item item)
        {
           
        }
        public void UseItem()
        {

        }
        public void RemoveItem( ) 
        {

        }
        public Item FindItem(Item item)
        {
            //인벤토리에 아이템이 존재하는지 확인

            

            return item;
        }

        private Item[] items;
    }
}
