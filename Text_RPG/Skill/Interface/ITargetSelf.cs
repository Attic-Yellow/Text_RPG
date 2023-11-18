using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;

namespace Text_RPG.Skill.Interface
{
    public interface ITargetSelf
    {
        public void SetTargetSelf(Character owner);
    }
}
