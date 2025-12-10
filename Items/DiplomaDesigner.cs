using FTKAPI.Managers;
using FTKAPI.Objects;
using GridEditor;
using UnityEngine;
using System.Collections.Generic;
using CommunityDLC;

namespace FTKModTemplate.Items
{
    using ProficiencyManager = FTKAPI.Managers.ProficiencyManager;
    public class DiplomaDesigner : CustomItem
    {
        public DiplomaDesigner()
        {
            ID = "DiplomaDesigner";
            Name = new CustomLocalizedString("Диплом дизайнера");
            Description = new CustomLocalizedString("Магическая книга дизайнера. Крошечная, но очень стильная.");

            int customProf = ProficiencyManager.AddProficiency(new DiplomaBlast());
                    
            // Если у тебя есть asset bundle с префабом — раскомментируй и укажи корректный путь:
            // Prefab = Plugin.assetBundle.LoadAsset<GameObject>("Assets/SomeBookPrefab.prefab");
            // Иначе можно не задавать Prefab — предмет будет без кастомной модели.
            //Prefab = Plugin.assetBundle.LoadAsset<GameObject>("Assets/customBladeSilver.prefab");

            // Двуручное оружие — проверь точное имя enum в Assembly-CSharp:
            // Попробуй так:
            ObjectSlot = FTK_itembase.ObjectSlot.twoHands; // <-- если компилятор ругается, см. ниже как узнать точное имя
            ObjectType = FTK_itembase.ObjectType.weapon;

            // Стат, от которого идёт сила оружия — ты просил "на удачу"
            SkillType = FTK_weaponStats2.SkillType.luck;

            // Тип оружия — книга (если такого конкретного варианта нет, поставь ближе всего)
            WeaponType = Weapon.WeaponType.book;

            // Привяжем какую-либо имеющуюся магическую атаку.
            // Вариант безопасный: используй существующий известный эффект (для теста можно взять bladePierceReg),
            // но лучше предварительно вывести список доступных FTK_proficiencyTable.ID и FTK_hitEffect.ID и выбрать нужный.
            ProficiencyEffects = new()
            { // these are the weapon attacks/skills for this custom item
                [(FTK_proficiencyTable.ID)customProf] = FTK_hitEffect.ID.magicAOEProf
            };

            // Анимация: попробуй найти контроллер с именем, подходящим для 2H book.
            AnimationController = AssetManager.GetAnimationControllers<Weapon>()
                .Find(i => i.name == "player_2H_Blunt_Combat");

            // Параметры урона
            Slots = 5;
            MaxDmg = 1;
            DmgGain = 0;
            DmgType = FTK_weaponStats2.DamageType.magic;

            NoRegularAttack = true;

            ShopStock = 1;
            TownMarket = true;
            DungeonMerchant = true;
            NightMarket = true;

            MaxLevel = 13;
            MinLevel = 7;

            // Редкость — если в твоей версии нет legendary, используй доступную (например common/rare)
            ItemRarity = FTK_itemRarityLevel.ID.common;

            GoldValue = 1;

            PriceScale = false;

            // Иконка — безопасный вариант: взять иконку уже существующего предмета
            //var someItem = ItemManager.GetItem(FTK_itembase.ID.tomeMage); // пример
            //if (someItem != null)
            //{
                Icon = AssetManager.LoadSpriteFromFile("FTKModTemplate/Assets/DiplomaBlast.png"); ;
                IconNonClickable = AssetManager.LoadSpriteFromFile("FTKModTemplate/Assets/DiplomaBlast.png");
        }
    }
}
