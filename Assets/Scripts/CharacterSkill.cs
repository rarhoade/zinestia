
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kryz.CharacterStats
{
    [Serializable]
    public class CharacterSkill : CharacterStat {

        public string derivedStat;
        public string description;
        public float multiplier;
        public string name;
        new protected readonly List<StatModifier> statModifiers;
        new public readonly ReadOnlyCollection<StatModifier> StatModifiers;
        public CharacterSkill(){
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }
        public CharacterSkill(float derivedStat, float multiplier) : this() 
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
            BaseValue = derivedStat * multiplier;
        }

        public float ApplySkillToStat(float inVal) {
            return inVal * this.CalculateFinalValue() * multiplier;
        }
    }
}
