using AAEmu.Game.Models.Game.Skills;
using AAEmu.Game.Models.Game.Units;

namespace AAEmu.Game.Models.Tasks.Skills
{
    public class ChannelingTask : SkillTask
    {
        private Unit _caster;
        private SkillCaster _casterCaster;
        private BaseUnit _target;
        private SkillCastTarget _targetCaster;

        public ChannelingTask(Skill skill, Unit caster, SkillCaster casterCaster, BaseUnit target, SkillCastTarget targetCaster) : base(skill)
        {
            _caster = caster;
            _casterCaster = casterCaster;
            _target = target;
            _targetCaster = targetCaster;
        }

        public override void Execute()
        {
            Skill.Channeling(_caster, _casterCaster, _target, _targetCaster);
        }
    }
}
