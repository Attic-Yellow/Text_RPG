using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Text_RPG
{
    public class Character : Entity
    {
        public int Level { get; set; }
        public int Magic { get; set; }
        public int MaxExp { get; set; }
        public string? Class { get; set; }

        public void LevelUp<T>(T character) where T : Character
        {
            switch (character.Class)
            {
                case "전사":
                    _stat.Health += 40 * Level + 330;
                    _stat.Attack += 3 * Level + 12;
                    _stat.Defense += 15;
                    break;
                case "마법사":
                    _stat.Health += 40 * Level + 330;
                    _stat.Attack += 3 * Level + 12;
                    _stat.Defense += 15;
                    break;
                case "궁수":
                    _stat.Health += 40 * Level + 330;
                    _stat.Attack += 3 * Level + 12;
                    _stat.Defense += 15;
                    break;
            }
        }
        public void SetStat()
        {
            switch (Class)
            {
                case "전사":

                    break;
                case "마법사":

                    break;
                case "궁수":

                    break;
            }
        }
        // 추가적인 스탯, 능력치, 장비 등의 속성
    }

    public class Warrior : Character
    {
        public Warrior(string name)
        {
            _stat.Name = name;
            _stat.Health = 840;
            _stat.MaxHealth = 840;
            _stat.Attack = 60;
            _stat.Defense = 50;
            _stat.Exp = 0;
            Level = 1;
            Class = "전사";
            MaxExp = 10;
        }
    }

    public class Mage : Character
    {
        public Mage(string name)
        {
            _stat.Name = name;
            _stat.Health = 500;
            _stat.MaxHealth = 500;
            _stat.Attack = 50;
            _stat.Defense = 30;
            _stat.Exp = 0;
            Level = 1;
            Class = "마법사";
            MaxExp = 10;
            // ... 다른 속성 초기화
        }
    }

    public class Archer : Character
    {
        public Archer(string name)
        {
            _stat.Name = name;
            _stat.Health = 500;
            _stat.MaxHealth = 500;
            _stat.Attack = 70;
            _stat.Defense = 30;
            _stat.Exp = 0;
            Level = 1;
            Class = "마법사";
            MaxExp = 10;
            // ... 다른 속성 초기화
        }
    }

}
