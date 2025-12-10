using FTKAPI.Objects;
using GridEditor;

namespace FTKModTemplate.Classes
{
    public class DesignerStudent : CustomClass
    {
        public DesignerStudent()
        {
            ID = "DesignerStudent";
            Name = new CustomLocalizedString("Дизайнер-студент");
            Description = new CustomLocalizedString("Хрупкий, засидевшийся за ноутбуком студент-дизайнер. Но удача любит тех, кто работает ночью!");

            // Деньги
            StartingGold = 3;

            // Статы – слабые
            Strength = 0.3f;
            Vitality = 0.8f;      // ? повысили живучесть
            Intelligence = 0.4f;
            Awareness = 0.4f;
            Talent = 0.4f;
            Speed = 0.4f;

            Luck = 1.2f;         // ? повышенная удача (основной стат)

            // Внешность
            IsMale = true;
            DefaultHeadSize = true;
        }
    }
}
