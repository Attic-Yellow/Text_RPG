using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Items
{
    public class Item
    {

        protected string itemName;
        protected string description;
        protected ItemTypes itemType;
        public enum ItemTypes { Equipment, Consumption, End }

        public string ItemName { get { return itemName; } }
        public ItemTypes ItemType {  get { return itemType; } }
        public string Description { get { return description; } }


        // 아이템의 효과, 타입, 사용 조건 등의 속성



    }
}
