using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Entity
{
    public class Entity
    {
        public string Name { get; set; }    // 이름
        public int Health { get; set; } 
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int Magic { get; set; }
    }

}
