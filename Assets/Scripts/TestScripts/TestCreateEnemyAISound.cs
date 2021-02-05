using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreateEnemyAISound : MonoBehaviour
{
    [SerializeField] GameObject TestSound;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0)) {
           var spawnPos = camera.ScreenToWorldPoint(Input.mousePosition);
           GameObject sound = Instantiate(TestSound, spawnPos, Quaternion.identity);
           sound.transform.position = new Vector3(
               sound.transform.position.x,
               sound.transform.position.y,
               0f
           );
           Destroy(sound, 5f);
       } 
    }
}
