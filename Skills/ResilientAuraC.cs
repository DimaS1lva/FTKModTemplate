using FTKAPI.Objects;
using GridEditor;

namespace FTKModTemplate
{
    public class ResilientAuraInfo : CustomSkill
    {
        public ResilientAuraInfo()
        {
            ID = "ResilientAura"; // уникальный идентификатор
            BaseSkill = FTK_characterSkill.ID.Discipline; // можно выбрать любую базовую способность
            HudDisplay = new CustomLocalizedString("Resilient Aura");
        }
    }
}
