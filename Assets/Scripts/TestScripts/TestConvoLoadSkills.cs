using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using Kryz.CharacterStats;

public class TestConvoLoadSkills : MonoBehaviour
{
    [SerializeField] SkillList playerSkillList;
    [SerializeField] Character playerChar;
    void OnValidate() {
        playerSkillList = GameObject.FindGameObjectWithTag("Player").GetComponent<SkillList>();
        playerChar = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    private void OnEnable() {
        Lua.RegisterFunction("GetSkill", this, SymbolExtensions.GetMethodInfo<String>((skill) => GetSkill(skill))); 
    }

    private void OnDisable() {
        Lua.UnregisterFunction("GetSkill");
    }

    double GetSkill(string skillName) {
        return (double)playerSkillList.GetSkill(skillName).Value;
    }

    bool CheckForPerk(string name) {
        foreach(Perk perk in playerChar.GetPerkList()) {
            if( perk.Name == name) {
                return true;
            }
        }
        return false;
    }

    bool CheckForItemInInventory(string itemName) {
        return false;
    }
}
