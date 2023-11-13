using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Battle
{
    internal abstract class Command
    {
        public int priority;
        public abstract void Execute();
    }
}
