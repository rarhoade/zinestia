using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;



public class Weapon : MonoBehaviour
{
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

    void Start() {
        SkillModifier = GetComponentInParent<SkillList>().GetSkill(DerivedSkill);
    }

    public void Activate() {
        gameObject.SetActive( true );
    }

    public void Deactivate() {
        gameObject.SetActive( false );
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
}
