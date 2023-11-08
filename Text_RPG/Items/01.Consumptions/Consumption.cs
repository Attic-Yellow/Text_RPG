using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Items.Consumptions
{
    internal abstract class Consumption : Item
    {
        public enum ConsumptionType { None, HelthItem, BuffItem }

        public Consumption()
        {
            m_itemType = ItemType.Consumption;
        }
        public abstract void UseItem();


        protected ConsumptionType m_consumptionType;

    }
}
