using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items.Equipments.Weapons;

namespace Text_RPG.Items.Equipments.Protectives
{
    internal class Armor : Protective
    {
        private int[] increaseHP;
        private int defensivePower;
        public Armor(int stage)
        {
            protectiveType = ProtectiveTypes.Armor;
            increaseHP = new int[(int)PlayerType.End];
            SettingItem(stage);

        }

        public override void SettingItem(int stage)
        {
            if (itemStage <= 1)
            {
                itemName = "브론즈 갑옷";
                increaseHP[(int)PlayerType.Warrior] = 150;
                increaseHP[(int)PlayerType.Mage] = 200;
                increaseHP[(int)PlayerType.Archor] = 200;
                defensivePower = 40;
                sellGold = 100;
                buyGold = 200;
                itemStage = 1;
            }
            else if (itemStage == 2)
            {
                itemName = "실버 갑옷";
                increaseHP[(int)PlayerType.Warrior] = 800;
                increaseHP[(int)PlayerType.Mage] = 1000;
                increaseHP[(int)PlayerType.Archor] = 1000;
                defensivePower = 100;
                sellGold = 150;
                buyGold = 300;
                itemStage = stage;
            }
            else if (itemStage == 3)
            {
                itemName = "골드 갑옷";
                increaseHP[(int)PlayerType.Warrior] = 1500;
                increaseHP[(int)PlayerType.Mage] = 1800;
                increaseHP[(int)PlayerType.Archor] = 1800;
                defensivePower = 120;
                sellGold = 200;
                buyGold = 400;

                itemStage = stage;
            }
            else if (itemStage == 4)
            {
                itemName = "플래티넘 갑옷";
                increaseHP[(int)PlayerType.Warrior] = 2000;
                increaseHP[(int)PlayerType.Mage] = 2500;
                increaseHP[(int)PlayerType.Archor] = 2500;
                defensivePower = 150;
                sellGold = 300;
                buyGold = 600;
                itemStage = stage;
            }
            else
            {
                itemName = "다이아몬드 갑옷";
                increaseHP[(int)PlayerType.Warrior] = 3500;
                increaseHP[(int)PlayerType.Mage] = 4000;
                increaseHP[(int)PlayerType.Archor] = 4000;
                defensivePower = 200;
                sellGold = 600;
                buyGold = 1200;
                itemStage = 5;
            }
        }
        public override Item DeepCopy()
        {
            Armor armor = new Armor(this.ItemStage);

            return armor;
        }
    }
}
