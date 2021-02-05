using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

namespace Kryz.CharacterStats 
{
    public class SkillList : MonoBehaviour
    {
        public TextAsset jsonSkillList;
        public List<CharacterSkill> Skills;

        [ContextMenu("Load Skills")]
        void LoadSkillsFromJson() {
            var jsonString = jsonSkillList.text;
            CharacterSkill[] skills = JsonHelper.getJsonArray<CharacterSkill>(jsonString);
            foreach(CharacterSkill skill in skills)
            {
                Skills.Add(skill);
            }
        }

        void OnValidate() {
            Skills = new List<CharacterSkill>();
        }
        void Awake() {
            Skills = new List<CharacterSkill>();
            LoadSkillsFromJson();
        }

        public CharacterSkill GetSkill(string name) {
            foreach( CharacterSkill skill in Skills ) {
                if ( name == skill.name) {
                    return skill;
                }
            }
            return null;
        }
    }
    public class JsonHelper {
        public static T[] getJsonArray<T>(string json)
        {
            string newJson = "{ \"array\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
            return wrapper.array;
        }
    
        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }
}

