using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateSaveButton : MonoBehaviour
{
    public CharacterSceneSaveManager characterSceneSaveManager;
    public InventoryInput inventoryInput;

    public string SaveName;
    public GameObject NewSaveTextInput;

    void Update() {
        if(NewSaveTextInput != null && NewSaveTextInput.activeSelf) {
            if(Input.GetKeyDown(KeyCode.Return)) {
                SaveName = NewSaveTextInput.GetComponent<TMP_InputField>().text + ".es3";
                SaveOnClick();
                inventoryInput.ToggleMenuInput(true);
                NewSaveTextInput.SetActive(false);
            }
        }
    }
    public void SaveOnClick() {
        Debug.Log("Saves/" + SaveName);
        characterSceneSaveManager.Save("Saves/" + SaveName);
    }

    public void NewSaveOnClick() {
        NewSaveTextInput.SetActive(true);
        inventoryInput.ToggleMenuInput(false);
    }
}
