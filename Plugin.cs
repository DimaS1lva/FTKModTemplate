using BepInEx;
using FTKAPI.Managers;
using FTKAPI.Objects;
using FTKModTemplate.Classes;
using FTKModTemplate.Items;
using GridEditor;
using HarmonyLib;
using UnityEngine;

namespace FTKModTemplate
{
    [BepInPlugin("FTKModTemplate", "FTK Mod Template", "0.1.0")]
    [BepInDependency("FTKAPI")]
    public class Plugin : BaseUnityPlugin
    {
        public static BaseUnityPlugin Instance;

        private void Awake()
        {
            Instance = this;
            Debug.Log("[FTKModTemplate] Plugin loaded!");

            // SkillSyncer (остаётся в Awake, он safe)
            NetworkManager.RegisterNetObject("FTKModTemplate.SkillSyncer",
                go => go.AddComponent<SkillSyncer>(),
                new()
            );

            // Harmony
            Harmony harmony = new Harmony(Info.Metadata.GUID);
            harmony.PatchAll();
        }
        class HarmonyPatches
        {
            [HarmonyPatch(typeof(TableManager), "Initialize")]
            class TableManager_Initialize_Patch
            {
                static void Postfix()
                {
                    // Skills
                    SkillContainer.Instance.Reset();
                    FTKAPI_CharacterSkill resilientAura = SkillContainer.Instance.resilientAura;
                    FTKAPI_CharacterSkill[] designerSkills = { resilientAura };
                    CustomCharacterSkills designerCharacterSkills = new CustomCharacterSkills()
                    {
                        Skills = designerSkills
                    };
                    // Skinset
                    FTK_skinset.ID[] standardSkinset = { FTK_skinset.ID.hobo_Male };
                    // Starting Weapon
                    int diplomaId = ItemManager.AddItem(new DiplomaDesigner(), Instance);
                    // Paladin
                    ClassManager.AddClass(new DesignerStudent() { Skinsets = standardSkinset, CharacterSkills = designerCharacterSkills, StartWeapon = (FTK_itembase.ID)diplomaId }, Instance); //Adds our paladin class
                }
            }
        }
    }
}