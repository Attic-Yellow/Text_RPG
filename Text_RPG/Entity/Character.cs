using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Text_RPG.Entity
{
    public class Character : Entity
    {
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        // 추가적인 스탯, 능력치, 장비 등의 속성
    }

    public class Warrior : Character
    {
        public Warrior()
        {
            Health = 100;
            Attack = 15;
            // ... 다른 속성 초기화
        }
    }

    public class Mage : Character
    {
        public Mage()
        {
            Health = 80;
            Attack = 10;
            Magic = 20;
            // ... 다른 속성 초기화
        }
    }

    public class Archer : Character
    {
        public Archer()
        {
            Health = 90;
            Attack = 12;
            // ... 다른 속성 초기화
        }
    }

}
