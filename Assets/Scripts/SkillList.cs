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
            //Debug.Log(skills);
            foreach(CharacterSkill skill in skills)
            {
                //Debug.Log(skill.name);
                Skills.Add(skill);
            }
        }

        void Awake() {
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

