using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Entity.Character
{
    public class Dealer : Character
    {
        public Dealer()
        {
            level = 1;
            maxHp = 500;
            currentHp = maxHp;
            attack = 70;
            defense = 30;
            critRate = 50;
            critPer = 30;

            skillList.Add(new Skill.Dealer.AttackBuff());
            skillList.Add(new Skill.Dealer.Counter());
            skillList.Add(new Skill.Dealer.Evasion());
            skillList.Add(new Skill.Dealer.ReduceArmor());
        }
        
        public override void LevelUp()
        {
            level++;
            maxHp += (28 * level) + 186;
            attack += (5 * level) + 9;
            defense += 10;
            critRate *= 2.4;
            critPer *= 1.2;
            
        }
    }
}
