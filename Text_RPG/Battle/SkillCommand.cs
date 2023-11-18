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
        public Character character;
        public Skill.Skill skill;
        public Monster monster;

        public SkillCommand(Character character, Skill.Skill skill)     // player -> monster
        {
            this.character = character;
            this.skill = skill;
            this.priority = skill.priority;
        }

        public SkillCommand(Monster monster, Skill.Skill skill)     // monster -> player
        {
            this.monster = monster;
            this.skill = skill;
            this.priority = skill.priority;
        }

        public override void Execute()
        {
            skill.Execute();
        }
    }
}
