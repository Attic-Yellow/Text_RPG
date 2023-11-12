using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Items.Equipments.Protectives
{
    internal class Hat : Protective
    {
        protected int[] defensivePower;
        private int increaseHP; 
        public Hat(int stage)
        {
            defensivePower = new int[(int)PlayerType.End];
            protectiveType = ProtectiveTypes.Hat;
            SettingItem(stage);
        }

        public override void SettingItem(int stage)
        {
            if (itemStage <= 1)
            {
                itemName = "브론즈 모자";
                defensivePower[(int)PlayerType.Warrior] = 40;
                defensivePower[(int)PlayerType.Mage] = 50;
                defensivePower[(int)PlayerType.Archor] = 50;
                increaseHP = 150;
                sellGold = 40;
                buyGold = 80;
                itemStage = 1;
            }
            else if (itemStage == 2)
            {
                itemName = "실버 모자";
                defensivePower[(int)PlayerType.Warrior] = 50;
                defensivePower[(int)PlayerType.Mage] = 70;
                defensivePower[(int)PlayerType.Archor] = 70;
                increaseHP = 400;
                sellGold = 100;
                buyGold = 200;

                itemStage = stage;
            }
            else if (itemStage == 3)
            {
                itemName = "골드 모자";
                defensivePower[(int)PlayerType.Warrior] = 60;
                defensivePower[(int)PlayerType.Mage] = 800;
                defensivePower[(int)PlayerType.Archor] = 80;
                increaseHP = 600;
                sellGold = 150;
                buyGold = 300;

                itemStage = stage;
            }
            else if (itemStage == 4)
            {
                itemName = "플래티넘 모자";
                defensivePower[(int)PlayerType.Warrior] = 80;
                defensivePower[(int)PlayerType.Mage] = 100;
                defensivePower[(int)PlayerType.Archor] = 100;
                increaseHP = 900;
                sellGold = 200;
                buyGold = 400;

                itemStage = stage;
            }
            else
            {
                itemName = "다이아몬드 모자";
                defensivePower[(int)PlayerType.Warrior] = 120;
                defensivePower[(int)PlayerType.Mage] = 160;
                defensivePower[(int)PlayerType.Archor] = 160;
                increaseHP = 1500;
                sellGold = 300;
                buyGold = 600;

                itemStage = 5;
            }
        }
        public override Item DeepCopy()
        {
            Hat hat = new Hat(this.ItemStage);

            return hat;
        }
    }
}
