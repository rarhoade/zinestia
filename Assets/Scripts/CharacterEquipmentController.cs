using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class CharacterEquipmentController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Hand;
    public Weapon equippedWeapon;
    CharacterMovement characterMovement;

    [SerializeField] SpriteLibrary equipmentLibrary;
    [SerializeField] SpriteLibrary armorLibrary;
    [SerializeField] GameObject characterWeapon;

    [SerializeField] string animationTrigger;

    void Start(){
        characterMovement = GetComponent<CharacterMovement>();
    }

    #region Exposed To Character Component
    public void Equip(EquippableItem item) {
        switch(item.EquipmentType) {
            case EquipmentType.Weapon1:
                Debug.Log("Weapon 1 Equip" + item.ItemName);
                characterMovement.attackAnimationTrigger = System.Enum.GetName(
                    typeof(AnimationTrigger), 
                    item.weaponMeta.TriggerKeyword
                ); 
                EquipWeapon(item.GamePrefab, item);
                SetWeaponAction(item.weaponMeta);
                break;
            case EquipmentType.BodyArmor:
                Debug.Log("BodyArmor Equip" + item.ItemName);
                EquipBodyArmor(item.GamePrefab);
                break;
            default: 
                break;
        }
    }

    public void Unequip(EquippableItem item) {
        switch(item.EquipmentType) {
            case EquipmentType.Weapon1:
                Debug.Log("Weapon 1 Unequip" + item.ItemName);
                characterMovement.attackAnimationTrigger = null;
                UnequipWeapon();
                break;
            case EquipmentType.BodyArmor:
                Debug.Log("BodyArmor Equip" + item.ItemName);
                UnequipBodyArmor();
                break;
            default: 
                break;
        }
    }

    #endregion

    void UnequipBodyArmor() {
        armorLibrary.spriteLibraryAsset = null;
        armorLibrary.gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }


    void EquipBodyArmor(GameObject armor) {
        armorLibrary.spriteLibraryAsset = armor.GetComponent<SpriteLibrary>().spriteLibraryAsset;
        armorLibrary.gameObject.GetComponent<SpriteResolver>().ResolveSpriteToSpriteRenderer();
    }

    void UnequipWeapon() {
        equipmentLibrary.spriteLibraryAsset = null;
        equipmentLibrary.gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    void EquipWeapon(GameObject weapon, EquippableItem item) {
        if(item.weaponMeta.type == WeaponType.Melee_Weapon) {
            BoxCollider2D box = characterWeapon.GetComponentInChildren<BoxCollider2D>();
            box.size = new Vector2(
                weapon.GetComponentInChildren<BoxCollider2D>().size.x,
                weapon.GetComponentInChildren<BoxCollider2D>().size.y
            );
            box.offset = new Vector2(
                weapon.GetComponentInChildren<BoxCollider2D>().offset.x,
                weapon.GetComponentInChildren<BoxCollider2D>().offset.y
            );
        } else if (item.weaponMeta.type == WeaponType.Ranged_Weapon) {
            Debug.Log("Ranged Weapon");
        }
        equipmentLibrary.spriteLibraryAsset = weapon.GetComponentInChildren<SpriteLibrary>().spriteLibraryAsset;
        equipmentLibrary.gameObject.GetComponent<SpriteResolver>().ResolveSpriteToSpriteRenderer();
    } 

    void SetWeaponAction(WeaponActionMeta meta) {
        equippedWeapon.myWeaponAttack = null;
        equippedWeapon.myWeaponAttack = meta.WeaponActionAttack;
    }
}
