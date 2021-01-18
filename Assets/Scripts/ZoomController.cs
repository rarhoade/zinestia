using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public float spriteHeight;
    private void OnGUI(){
        Camera.main.orthographicSize = Screen.height/spriteHeight/2.0f;
    }
}
