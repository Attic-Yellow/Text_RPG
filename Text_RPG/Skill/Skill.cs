using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Skill
{
    public abstract class Skill
    {
        public string name;
        public int priority;
        public int cooldown;
        public abstract void Execute();
    }
}
