using FTKAPI.Managers;
using Logger = FTKAPI.Utils.Logger;

namespace FTKModTemplate
{
    public class SkillContainer
    {
        public static SkillContainer instance;
        public static SkillContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    Logger.LogWarning("Initializing SkillContainer...");
                    instance = new SkillContainer();
                }
                return instance;
            }
        }

        internal SkillSyncer skillSyncer;

        public ResilientAura resilientAura;

        public SkillContainer()
        {
            // Инициализация скиллов
            Reset();
        }

        public void Reset()
        {
            // Только кастомные скиллы
            resilientAura = new ResilientAura(this);
        }

        public void SyncResilient(bool proc)
        {
            skillSyncer?.SyncResilient(proc);
        }

        public SkillSyncer Syncer
        {
            get => skillSyncer;
            set => skillSyncer = value;
        }
    }
}
