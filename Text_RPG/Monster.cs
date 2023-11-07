using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public class Monster : Entity
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Exp { get; set; }   
        // 추가적인 스탯, 능력치, 드롭 아이템 등의 속성
    }

}
