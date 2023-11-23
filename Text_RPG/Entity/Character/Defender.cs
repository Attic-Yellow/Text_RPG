using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Entity.Character
{
    public class Defender : Character
    {
      
        public Defender(Player owner) : base(owner)
        {
            level = 1;
            maxHp = 840;
            currentHp = maxHp;
            attack = 60;
            defense = 50;
            critRate = 40;
            critPer = 20;

            skillList.Add(new Skill.Defender.CounterForAll(this));
            skillList.Add(new Skill.Defender.DeffenseBuff(this));
            skillList.Add(new Skill.Defender.Provoke(this));
            skillList.Add(new Skill.Defender.Shield(this));
        }

        public override void LevelUp()
        {
            level++;
            maxHp += (40 * level) + 330;
            attack += (3 * level) + 12;
            defense += 15;
            critRate *= 1.5;
            critPer *= 1.0;

        }
    }
}
