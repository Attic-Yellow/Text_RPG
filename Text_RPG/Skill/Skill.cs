﻿using System;
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
        public Player player;
        public Entity.Entity owner;
        public string name;
        public int priority;
        public int cooldown;
        public List<List<Entity.Entity>> targetList;

        public Skill(Entity.Entity owner, List<List<Entity.Entity>> targetList)
        {
            this.owner = owner;
            this.targetList = targetList;
        }

        public abstract void Execute();
        public abstract void SetTarget();
    }
}
