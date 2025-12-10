using FTKAPI.Managers;
using FTKAPI.Objects;
using GridEditor;
using System.Collections.Generic;
using System.Linq;
using Logger = FTKAPI.Utils.Logger;
using FTKModTemplate;

namespace FTKModTemplate
{
    public class ResilientAura : FTKAPI_CharacterSkill
    {
        internal SkillContainer skillContainer;

        public ResilientAura(SkillContainer _container)
        {
            skillContainer = _container;
            int customSkill = SkillManager.AddSkill(new ResilientAuraInfo());
            Name = new CustomLocalizedString("Resilient Aura");
            Description = new CustomLocalizedString("When taking damage, gain +Defense and +Resistance for 1 turn.");
            Trigger = TriggerType.RespondToHit;
            SkillInfo = (FTK_characterSkill.ID)customSkill;
        }

        public override void Skill(CharacterOverworld _player, TriggerType _trig)
        {
            if (_trig == TriggerType.RespondToHit) { Logger.LogWarning("[ResilientAura] Responded To Hit"); }
            if (_trig == TriggerType.RespondToHit)
            {
                var dummy = _player.m_CurrentDummy;
                dummy.AddProfToDummy(new FTK_proficiencyTable.ID[] {
                    FTK_proficiencyTable.ID.musicArmorUp3,
                    FTK_proficiencyTable.ID.magicResistUp3
                }, true, true);
                dummy.PlayCharacterAbilityEventRPC(FTK_characterSkill.ID.None);
                Logger.LogWarning("Resilient Aura triggered for " + _player.name);
            }
        }
    }
}