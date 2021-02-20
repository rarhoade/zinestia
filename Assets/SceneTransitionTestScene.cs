using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTestScene : MonoBehaviour
{
    [SerializeField] Scene currentEnvironment;
    [SerializeField] Scene sceneToLoad;
    void Awake() {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            SceneManager.UnloadSceneAsync("SampleScene_Environment_1", UnloadSceneOptions.None);
            SceneManager.LoadScene("SampleScene_Environment_2", LoadSceneMode.Additive);
        }
    }
}
