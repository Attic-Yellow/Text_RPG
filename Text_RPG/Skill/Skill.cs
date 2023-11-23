using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity;
using Text_RPG.Entity.Character;
using Text_RPG.Entity.Monster;
using Text_RPG.Skill.Interface;
using Text_RPG.UI;

namespace Text_RPG.Skill
{
    public abstract class Skill : ITargetable, IExecutable
    {
        public Entity.Entity owner;
        public string name;
        public int priority;
        public int cooldown;

        public Skill(Entity.Entity owner)
        {
            this.owner = owner;
        }

        public abstract void Execute();
        public abstract void SetTarget();
    }
}
