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
        public int Attack { get; set; }
        public int Defense { get; set; }
        // 추가적인 스탯, 능력치, 장비 등의 속성
    }

}
