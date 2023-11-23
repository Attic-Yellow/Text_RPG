using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Entity.Monster
{
    public class Monster : Entity
    {
        public int maxHp { get; set; }
        public int currentHp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int exp { get; set; }

        public int gold { get; set; }
        public List<Items.Item> itemDropList { get; set; }


        public Monster()
        {
            skillList.Add(new Skill.Common.Attack(this));
            skillList.Add(new Skill.Common.HardAttack(this));
            skillList.Add(new Skill.Common.Monster.GroupAttack(this));
            skillList.Add(new Skill.Common.Monster.Recover(this));
        }
        // 추가적인 스탯, 능력치, 드롭 아이템 등의 속성
    }

}
