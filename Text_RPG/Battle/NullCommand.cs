using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;

namespace Text_RPG.Battle
{
    /// <summary>
    /// 죽은 캐릭터 커맨드 자동 설정
    /// </summary>
    internal class NullCommand : Command
    {
        public Character character;
        public NullCommand(Character character)
        {
            priority = 0;
        }
        public override void Execute()
        {
            return;
        }
    }
}
