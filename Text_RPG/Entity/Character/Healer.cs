using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Entity.Character
{
    public class Healer : Character
    {
        public Healer(Player owner) : base(owner)
        {
            level = 1;
            maxHp = 500;
            currentHp = maxHp;
            attack = 50;
            defense = 30;
            critRate = 40;
            critPer = 20;


            skillList.Add(new Skill.Healer.Heal(this));
            skillList.Add(new Skill.Healer.HealForAll(this));
            skillList.Add(new Skill.Healer.ReduceAttack(this));
            skillList.Add(new Skill.Healer.ShieldForAll(this));
        }

        public override void LevelUp()
        {
            level++;
            maxHp += (28 * level) + 186;
            attack += (2 * level) + 9;
            defense += 10;
            critRate *= 1.5;
            critPer *= 1.0;

        }
    }
}
