using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject InventoryPanel;
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.I) ) {
            InventoryPanel.SetActive(!InventoryPanel.activeSelf);
        }
    }
}
