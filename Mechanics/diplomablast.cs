using FTKAPI.Managers;
using FTKAPI.Objects;
using GridEditor;
using UnityEngine;

namespace CommunityDLC
{
    public class DiplomaBlast : CustomProficiency
    {
        public DiplomaBlast()
        {
            // Уникальный ID и название
            ID = "diploma_blast";
            Name = new("Diploma Blast");

            // Слот книги
            SlotOverride = 5;

            // Тип оружия — книга
            WpnTypeOverride = Weapon.WeaponType.book;

            // Тип урона — магический
            DmgTypeOverride = FTK_weaponStats2.DamageType.magic;

            // Цель — все враги
            Target = CharacterDummy.TargetType.Aoe;

            // Урон фиксированный 1
            DamagePerAttack = 1;

            // Количество ячеек — 5
            FullSlots = true;

            // Категория умения 
            Category = Category.Lightning;

            // Цвет кнопки в бою
            Tint = new Color(0.8f, 0.5f, 1f, 1f);

            // Иконка умения (замени на свою)
            //BattleButton = CommunityDLC.assetBundleIcons.LoadAsset<Sprite>("Assets/Icons/diplomaBook.png")
            BattleButton = AssetManager.LoadSpriteFromFile("FTKModTemplate/Assets/DiplomaBlast.png");
            // Эффекты: шанс 100% для дебафов, но накладываются только при выбивании всех 5 ячеек
            ChanceToAffect = 1f;
        }
    }
}
