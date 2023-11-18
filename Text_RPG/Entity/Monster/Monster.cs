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

        public List<Skill.Skill> skillList = new List<Skill.Skill>();

        public Monster()
        {
            skillList.Add(new Skill.Common.Attack());
            skillList.Add(new Skill.Common.HardAttack());
            skillList.Add(new Skill.Common.Monster.GroupAttack());
            skillList.Add(new Skill.Common.Monster.Recover());
        }
        // 추가적인 스탯, 능력치, 드롭 아이템 등의 속성
    }

}
