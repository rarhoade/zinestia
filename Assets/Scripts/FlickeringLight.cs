using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] Light2D[] lights;
    Light2D prevLight;
    [SerializeField] int flickerIterations;
    // Start is called before the first frame update
    void Start()
    {
        lights = GetComponentsInChildren<Light2D>();
        StartCoroutine("Flicker");
    }

    IEnumerator Flicker(){
        while (true) {
            for(int i = 0; i < lights.Length * flickerIterations; i++){
                yield return new WaitForSeconds(0.015f);
                if (prevLight)
                    prevLight.enabled = false;
                prevLight = lights[i/flickerIterations];
                prevLight.enabled = true; 
            }
            yield return new WaitForSeconds(Random.Range(3.0f, 6.0f));
        }
    }
}
