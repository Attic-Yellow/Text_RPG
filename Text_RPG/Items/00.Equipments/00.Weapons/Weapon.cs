using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items.Equipments;
using Text_RPG.Items.Equipments.Protectives;

namespace Text_RPG.Items.Equipments.Weapons
{
    internal class Weapon : Equipment
    {

        protected int[] attackPower;
        protected int criticalPower;
        public Weapon(int stage)
        {
            equipType = EquipmentTypes.Weapon;
            attackPower = new int[(int)PlayerType.End];
            SettingItem(stage);
        }

        public override void SettingItem(int stage)
        {
            if (itemStage <= 1)
            {
                itemName = "브론즈 무기";
                attackPower[(int)PlayerType.Warrior] = 20;
                attackPower[(int)PlayerType.Mage] = 20;
                attackPower[(int)PlayerType.Archor] = 20;
                criticalPower = 10;
                itemStage = 1;
                sellGold = 50;
                buyGold = 100;
            }
            else if (itemStage == 2)
            {
                itemName = "실버 무기";
                attackPower[(int)PlayerType.Warrior] = 100;
                attackPower[(int)PlayerType.Mage] = 80;
                attackPower[(int)PlayerType.Archor] = 80;
                criticalPower = 30;
                itemStage = stage;
                sellGold = 120;
                buyGold = 240;
            }
            else if (itemStage == 3)
            {
                itemName = "골드 무기";
                attackPower[(int)PlayerType.Warrior] = 200;
                attackPower[(int)PlayerType.Mage] = 160;
                attackPower[(int)PlayerType.Archor] = 160;
                criticalPower = 30;
                itemStage = stage;
                sellGold = 180;
                buyGold = 360;
            }
            else if (itemStage == 4)
            {
                itemName = "플래티넘 무기";
                attackPower[(int)PlayerType.Warrior] = 350;
                attackPower[(int)PlayerType.Mage] = 300;
                attackPower[(int)PlayerType.Archor] = 300;
                criticalPower = 50;
                itemStage = stage;
                sellGold = 250;
                buyGold = 500;
            }
            else
            {
                itemName = "다이아몬드 무기";
                attackPower[(int)PlayerType.Warrior] = 600;
                attackPower[(int)PlayerType.Mage] = 500;
                attackPower[(int)PlayerType.Archor] = 500;
                criticalPower = 70;
                itemStage = 5;
                sellGold = 450;
                buyGold = 900;
            }
        }
        public override Item DeepCopy()
        {
            Weapon weapon = new Weapon(this.ItemStage);

            return weapon;
        }
    }
}
