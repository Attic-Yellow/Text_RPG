using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Items.Equipments
{
    internal class Equipment : Item
    {
        public enum EquipmentTypes { Weapon, Protective,End}
        public Equipment()
        {
            itemType = ItemTypes.Equipment;
        }


        protected EquipmentTypes equipType;



    }
}
