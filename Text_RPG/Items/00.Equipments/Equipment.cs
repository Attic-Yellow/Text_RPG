using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Items.Equipments
{
    internal class Equipment : Item
    {
        public enum EquipmentType { None, Weapon, Protective }
        public Equipment()
        {
            m_itemType = ItemType.Equipment;
        }


        protected EquipmentType m_equipType;



    }
}
