using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;
using Text_RPG.Entity.Monster;
using Text_RPG.Skill.Interface;
using Text_RPG.UI;

namespace Text_RPG.Skill
{
    public abstract class Skill : ITargetSelf, ITargetAll, ITargetOne, ITargetPlayer
    {
        public string name;
        public int priority;
        public int cooldown;
        public Character character;
        public Character[] characters;
        public Monster monster;
        public Player player;

        public abstract void Execute();
        public void SetTarget(Character target) 
        {
            this.character = target;
        }

        public void SetTargetAll(Character[] targets)
        {
            this.characters = targets;
        }

        public void SetTargetSelf(Character owner)
        {
            this.character = owner;
        }

        public void SetTargetPlayer(Player player)
        {
            this.player = player;
        }
    }
}
