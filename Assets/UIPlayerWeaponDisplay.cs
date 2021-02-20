using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Kryz;

public class UIPlayerWeaponDisplay : MonoBehaviour
{
    public TextMeshProUGUI WeaponName;
    public TextMeshProUGUI AmmoDisplay;

    void Start()
    {
        Weapon.OnWeaponShoot += UpdateAmmoDisplay;
        Weapon.OnWeaponReload += UpdateAmmoDisplay;
        
        Weapon.OnWeaponEquip += UpdateWeaponName;
        Weapon.OnWeaponEquip += UpdateAmmoDisplay;

        Weapon.OnSceneInitialization += UpdateAmmoDisplay;
        Weapon.OnSceneInitialization += UpdateWeaponName;
    }

    void UpdateWeaponName(EquippableItem item) {
        if(item != null)
            WeaponName.text = item.ItemName;
    }

    void UpdateAmmoDisplay(EquippableItem item) {
        if(item != null && item.weaponMeta is RangedWeaponActionMeta) {
            RangedWeaponActionMeta meta = (RangedWeaponActionMeta)item.weaponMeta;
            AmmoDisplay.text = (item.currentClip.ToString() + "/" + meta.clipSize.ToString());
        } else if (item != null) {
            AmmoDisplay.text = ("-/-");
        }
    }
}
