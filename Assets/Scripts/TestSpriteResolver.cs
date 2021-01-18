using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class TestSpriteResolver : MonoBehaviour
{
    [SerializeField] SpriteLibraryAsset spriteLibraryAssetWalking;
    [SerializeField] SpriteLibrary spriteLibrary;
    [SerializeField] SpriteLibraryAsset altSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteLibrary = GetComponent<SpriteLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) {
            spriteLibrary.spriteLibraryAsset = altSprite;
            spriteLibrary.RefreshSpriteResolvers();
        }

    }
}
