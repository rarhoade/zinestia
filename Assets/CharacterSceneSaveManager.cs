using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSceneSaveManager : MonoBehaviour
{
    public GameObject Character;
    public Canvas playerUI;
    public PauseMenu pauseMenu;

    void Start() {
        pauseMenu = GetComponent<PauseMenu>();
    }

    public void Save(string fileName) {
        var es3File = new ES3File(fileName);
        es3File.Save("character", Character);
        es3File.Save("playerUI", playerUI);
        es3File.Sync();
        pauseMenu.SaveMenuButton();
        pauseMenu.TogglePause();
    }

    public void Load(string fileName) {
        var es3File = new ES3File(fileName);
        es3File.LoadInto("character", Character);
        es3File.LoadInto("playerUI", playerUI);
        pauseMenu.LoadMenuButton();
        pauseMenu.TogglePause();
    }
}
