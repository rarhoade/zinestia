using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == 8){
            col.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.layer == 8){
            col.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.layer == 8){
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
