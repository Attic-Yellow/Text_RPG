using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Battle
{
    /// <summary>
    /// 우선순위, 커맨드 발동 메서드
    /// </summary>
    public abstract class Command
    {
        public int priority;
        public abstract void Execute();
    }
}
