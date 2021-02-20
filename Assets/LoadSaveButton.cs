using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadSaveButton : MonoBehaviour
{
    public Button button;
    public CharacterSceneSaveManager characterSceneSaveManager;
    public string SaveName;
    void Start() {
        button = GetComponent<Button>();   
    }

    public void LoadSaveClick() {
        Debug.Log("Being clicked");
        characterSceneSaveManager.Load("Saves/" + SaveName);
    }

}
