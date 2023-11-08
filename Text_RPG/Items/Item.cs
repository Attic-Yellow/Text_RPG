using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Items
{
    public class Item
    {
        public enum ItemType { None, Equipment, Consumption }
          
        public string ItemName { get { return m_itemName; } }
        public string Description { get { return m_description; } }


        // 아이템의 효과, 타입, 사용 조건 등의 속성



        protected string m_itemName;
        protected string m_description;
        protected ItemType m_itemType;

    }
}
