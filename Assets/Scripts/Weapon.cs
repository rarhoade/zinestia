using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;



public class Weapon : MonoBehaviour
{
    public Character character;
    public Animator weaponAnimator;
    public string attackAnimationTrigger;
    protected bool equipped;
    protected bool canAttack = true;
    public float BaseDamageMin;
    public float BaseDamageMax;
    [SerializeField]
    protected float modifiedMinDamage;
    [SerializeField]
    protected float modifiedMaxDamage;

    [SerializeField]
    protected CharacterSkill SkillModifier;
    public string DerivedSkill;
    public delegate void WeaponAttack(GameObject gameObject);
    public WeaponAttack myWeaponAttack;
    public EquippableItem weaponItem;

    public static Action<EquippableItem> OnWeaponShoot;
    public static Action<EquippableItem> OnWeaponReload;
    public static Action<EquippableItem> OnWeaponEquip;
    public static Action<EquippableItem> OnSceneInitialization;
    void Start() {
        SkillModifier = GetComponentInParent<SkillList>().GetSkill(DerivedSkill);
        character = GetComponentInParent<Character>();
        if(weaponItem)
            OnSceneInitialization(weaponItem);
    }

    public void LateUpdate() {
        if(weaponItem) {
            if (Input.GetButtonDown("Fire1") && attackAnimationTrigger != null)
            {
                if(weaponItem.weaponMeta.type == WeaponType.Ranged_Weapon && weaponItem.currentClip > 0) {
                    weaponAnimator.SetTrigger(attackAnimationTrigger);
                } else if (weaponItem.weaponMeta.type == WeaponType.Melee_Weapon) {
                    weaponAnimator.SetTrigger(attackAnimationTrigger);
                }
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                RangedWeaponActionMeta meta = (RangedWeaponActionMeta)weaponItem.weaponMeta;
                for(var i = 0; i < meta.clipSize; i++) {
                    if(weaponItem.currentClip < meta.clipSize && character.Inventory.RemoveItem(meta.weaponAmmunition)) {
                        weaponItem.currentClip++; 
                    }
                    OnWeaponReload(weaponItem);
                }
            }
        }
        
    }

    public void Activate() {
        gameObject.SetActive( true );
    }

    public void Deactivate() {
        gameObject.SetActive( false );
    }

    //called during weapon animations to engage actions set on weapons
    public void ExecuteAttack() {
        if(weaponItem.weaponMeta.type == WeaponType.Ranged_Weapon) {
            //take one from clip
            weaponItem.currentClip -= 1;
            OnWeaponShoot(weaponItem);
            myWeaponAttack(gameObject);
        } else if(weaponItem.weaponMeta.type == WeaponType.Melee_Weapon) {
            myWeaponAttack(gameObject);
        }
    }

    public void SetEquipped( bool status ) {
        equipped = status;
        CalculateDamageRange();
    }

    public void CalculateDamageRange() {
        if ( equipped == true ) {
            modifiedMinDamage = SkillModifier.ApplySkillToStat(BaseDamageMin);
            modifiedMaxDamage = SkillModifier.ApplySkillToStat(BaseDamageMax);
            GetComponentInParent<Character>().CheckPerks(PerkTypes.WeaponDamageModifier, this.gameObject);
        } else {
            modifiedMinDamage = 0;
            modifiedMaxDamage = 0;
        }
    }

    public void ApplyDamageMultiplier( float mod ) {
        modifiedMinDamage *= mod;
        modifiedMaxDamage *= mod;
    }

    public bool GetEquipped() {
        return equipped;
    }

    public float GetDamage() {
        return UnityEngine.Random.Range(modifiedMinDamage, modifiedMaxDamage);
    }    

    public virtual IEnumerator AttackCooldown(float time) {
        canAttack = false;
        yield return new WaitForSecondsRealtime(time);
        canAttack = true;
    }

    public void SetWeaponItem(EquippableItem item) {
        OnWeaponEquip(item);
        weaponItem = item;
    }
}
