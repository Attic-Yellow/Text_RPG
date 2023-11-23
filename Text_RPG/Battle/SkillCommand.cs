using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;
using Text_RPG.Entity.Monster;
using Text_RPG.Skill;

namespace Text_RPG.Battle
{
    /// <summary>
    /// 스킬 시전자, 스킬, 우선순위
    /// </summary>
    public class SkillCommand : Command
    {
        public Entity.Entity entity;
        public Skill.Skill skill;

        public SkillCommand(Entity.Entity entity, Skill.Skill skill)
        {
            this.entity = entity;
            this.skill = skill;
            this.priority = skill.priority;
        }


        public override void Execute()
        {
            skill.Execute();
        }
    }
}
