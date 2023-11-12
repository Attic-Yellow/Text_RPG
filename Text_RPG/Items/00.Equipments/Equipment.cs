using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Items.Equipments
{
    internal abstract class Equipment : Item
    {

        protected int itemStage;
        public enum PlayerType { Warrior, Mage, Archor, End }
        public enum EquipmentTypes { Weapon, Protective,End}
        public Equipment()
        {
            itemType = ItemTypes.Equipment;
        }
        public int ItemStage { get { return itemStage; } }

        public abstract void SettingItem(int stage);
        protected EquipmentTypes equipType;



    }
}
