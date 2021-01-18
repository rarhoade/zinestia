using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipmentController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Hand;
    public Weapon equippedWeapon;
    CharacterMovement characterMovement;

    void Start(){
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Equip(EquippableItem item) {
        switch(item.EquipmentType) {
            case EquipmentType.Weapon1:
                Debug.Log("Weapon 1 Equip" + item.ItemName);
                EquipWeapon(item.GamePrefab);
                break;
            default: 
                break;
        }
    }

    public void Unequip(EquippableItem item) {
        switch(item.EquipmentType) {
            case EquipmentType.Weapon1:
                Debug.Log("Weapon 1 Unequip" + item.ItemName);
                break;
            default: 
                break;
        }
    }

    public void EquipWeapon(GameObject weapon){
        if( equippedWeapon && equippedWeapon.GetEquipped() ) {
            //weapon is equipped
            foreach ( Transform child in Hand) {
                //unequip weapons
                GameObject.Destroy(child.gameObject);
            }
        } 
        //if weapon passed in
        if( weapon ) {
            var instanceWeapon = Instantiate(weapon, Hand);
            equippedWeapon = instanceWeapon.GetComponent<Weapon>();
            characterMovement.weapon = instanceWeapon;
            equippedWeapon.SetEquipped(true);
        } else {
            //else don't do anything
            characterMovement.weapon = null;
        }
    } 
}
