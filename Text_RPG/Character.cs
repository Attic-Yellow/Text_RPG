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
        public int Exp { get; set; }
        // 추가적인 스탯, 능력치, 장비 등의 속성
    }

    public class Warrior : Character
    {
        public Warrior(string name)
        {
            this.Name = name;
            this.Health = 100;
            this.Attack = 15;
            // ... 다른 속성 초기화
        }
    }

    public class Mage : Character
    {
        public Mage(string name)
        {
            this.Name = name;
            this.Health = 80;
            this.Attack = 10;
            this.Magic = 20;
            // ... 다른 속성 초기화
        }
    }

    public class Archer : Character
    {
        public Archer(string name)
        {
            this.Name = name;
            this.Health = 90;
            this.Attack = 12;
            // ... 다른 속성 초기화
        }
    }

}
