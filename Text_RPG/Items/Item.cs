using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Items
{
    public abstract class Item
    {

        protected string itemName;
        protected string description;
        protected int sellGold;
        protected int buyGold;

        protected ItemTypes itemType;
        public enum ItemTypes { Equipment, Consumption, End }

        public int BuyGold { get { return buyGold;} }
        public int SellGold { get { return sellGold; } }
        public string ItemName { get { return itemName; } }
        public ItemTypes ItemType {  get { return itemType; } }
        public string Description { get { return description; } }

        public abstract Item DeepCopy();

        // 아이템의 효과, 타입, 사용 조건 등의 속성



    }
}
