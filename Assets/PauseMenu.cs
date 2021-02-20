using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    bool GameIsPaused;
    // Start is called before the first frame update
    [SerializeField] GameObject PauseMenuUIElements;
    [SerializeField] GameObject LoadMenuContent;
    [SerializeField] GameObject SaveMenuContent;
    GameObject loadMenu;
    GameObject saveMenu;
    public GameObject LoadButtonPrefab;
    public GameObject SaveButtonPrefab;
    void Start()
    {
        GameIsPaused = false;
        loadMenu = LoadMenuContent.transform.parent.parent.parent.gameObject;
        saveMenu = SaveMenuContent.transform.parent.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameIsPaused == true) {
            Pause();
        } else {
            Resume();
        }
    }

    public void TogglePause() {
        bool newState = !PauseMenuUIElements.activeSelf;
        PauseMenuUIElements.SetActive(newState);
        GameIsPaused = newState; 

        if(newState == true) {
            loadMenu.SetActive(false);
            saveMenu.SetActive(false);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
    }

    public void Resume() {
        Time.timeScale = 1f;
    }

    public void Quit() {
        if(UnityEditor.EditorApplication.isPlaying){
            UnityEditor.EditorApplication.isPlaying = false;
        } else {
            Application.Quit();
        }
    }

    public void LoadMenuButton() {
        
        if(loadMenu.activeSelf) {
            loadMenu.SetActive(false);
        } else {
            PauseMenuUIElements.SetActive(false);
            if(LoadMenuContent.transform.childCount > 0) {
                foreach(Transform child in LoadMenuContent.transform) {
                    Destroy(child.gameObject);
                }
            }

            foreach(var fileName in ES3.GetFiles("Saves/")){
                GameObject loadButton = Instantiate(LoadButtonPrefab, LoadMenuContent.transform);
                loadButton.GetComponentInChildren<TextMeshProUGUI>().text = fileName;
                loadButton.GetComponent<LoadSaveButton>().characterSceneSaveManager = GetComponent<CharacterSceneSaveManager>();
                loadButton.GetComponent<LoadSaveButton>().SaveName = fileName;
            }
            loadMenu.SetActive(true);
        }
    }

    public void SaveMenuButton() {
        
        if(saveMenu.activeSelf) {
            saveMenu.SetActive(false);
        } else {
            PauseMenuUIElements.SetActive(false);

            if(SaveMenuContent.transform.childCount > 1) {
                int counter = 1;
                foreach(Transform child in SaveMenuContent.transform) {
                    if(counter > 1) {
                        Destroy(child.gameObject);
                    } 
                    counter++;
                }
            }

            foreach(var fileName in ES3.GetFiles("Saves/")){
                GameObject saveButton = Instantiate(SaveButtonPrefab, SaveMenuContent.transform);
                saveButton.GetComponentInChildren<TextMeshProUGUI>().text = fileName;
                saveButton.GetComponent<CreateSaveButton>().characterSceneSaveManager = GetComponent<CharacterSceneSaveManager>();
                saveButton.GetComponent<CreateSaveButton>().SaveName = fileName;
            }
            saveMenu.SetActive(true);
        }
    }
}
