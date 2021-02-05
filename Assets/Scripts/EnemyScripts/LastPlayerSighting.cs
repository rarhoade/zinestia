using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPlayerSighting : MonoBehaviour
{
    public Vector3 position = new Vector3(1000f, 1000f, 1000f);
    //reset position is used as a pos that the player can never reach and will
    //be a check that the player hasn't been seen
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);

    
}
