using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items.Equipments.Weapons;

namespace Text_RPG.Items.Equipments.Protectives
{
    internal class Shoes : Protective
    {
        private int[] criticalPower;
        private int increaseHP;
        public Shoes(int stage)
        {
            protectiveType = ProtectiveTypes.Shoes;
            criticalPower = new int[(int)PlayerType.End];
            SettingItem(stage);
        }

        public override void SettingItem(int stage)
        {
            if (itemStage <= 1)
            {
                itemName = "브론즈 신발";
                criticalPower[(int)PlayerType.Warrior] = 5;
                criticalPower[(int)PlayerType.Mage] = 5;
                criticalPower[(int)PlayerType.Archor] = 5;
                increaseHP = 150;
                sellGold = 40;
                buyGold = 80;
                itemStage = 1;
            }
            else if (itemStage == 2)
            {
                itemName = "실버 신발";
                criticalPower[(int)PlayerType.Warrior] = 12;
                criticalPower[(int)PlayerType.Mage] = 10;
                criticalPower[(int)PlayerType.Archor] = 10;
                increaseHP = 400;
                sellGold = 100;
                buyGold = 200;

                itemStage = stage;

            }
            else if (itemStage == 3)
            {
                itemName = "골드 신발";
                criticalPower[(int)PlayerType.Warrior] = 15;
                criticalPower[(int)PlayerType.Mage] = 10;
                criticalPower[(int)PlayerType.Archor] = 10;
                increaseHP = 600;
                sellGold = 150;
                buyGold = 300;
                itemStage = stage;
            }
            else if (itemStage == 4)
            {
                itemName = "플래티넘 신발";
                criticalPower[(int)PlayerType.Warrior] = 20;
                criticalPower[(int)PlayerType.Mage] = 15;
                criticalPower[(int)PlayerType.Archor] = 15;
                increaseHP = 900;
                sellGold = 200;
                buyGold = 400;
                itemStage = stage;
            }
            else
            {
                itemName = "다이아몬드 신발";
                criticalPower[(int)PlayerType.Warrior] = 30;
                criticalPower[(int)PlayerType.Mage] = 20;
                criticalPower[(int)PlayerType.Archor] = 20;
                increaseHP = 1500;
                sellGold = 300;
                buyGold = 600;

                itemStage = 5;
            }
        }
        public override Item DeepCopy()
        {
            Shoes shoes = new Shoes(this.ItemStage);

            return shoes;
        }
    }
}
