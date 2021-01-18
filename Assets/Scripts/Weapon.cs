using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;

public class Weapon : MonoBehaviour
{
    protected bool equipped;
    protected bool canAttack = true;
    public float CooldownTime = 0.1f;
    public float BaseDamageMin;
    public float BaseDamageMax;
    [SerializeField]
    protected float modifiedMinDamage;
    [SerializeField]
    protected float modifiedMaxDamage;

    [SerializeField]
    protected CharacterSkill SkillModifier;
    public string DerivedSkill;


    void Start() {
        //SkillModifier = GetComponentInParent<Character>().skillList.GetSkill("Melee Weapons");
    }

    void Update() {
        if( Input.GetKeyDown( KeyCode.E ) ){
            SetEquipped(true);
        }
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
        if( equipped == true ) {
            modifiedMinDamage = SkillModifier.ApplySkillToStat(BaseDamageMin);
            modifiedMaxDamage = SkillModifier.ApplySkillToStat(BaseDamageMax);
            //GetComponentInParent<Character>().CheckPerks(PerkTypes.WeaponDamageModifier, this.gameObject);
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
        return Random.Range(modifiedMinDamage, modifiedMaxDamage);
    }    

    public virtual void Attack() {
        if(canAttack) {
            GetComponent<Animator>().SetTrigger("Attack");
            StartCoroutine("AttackCooldown", CooldownTime);
        }
    }

    public virtual IEnumerator AttackCooldown(float time) {
        canAttack = false;
        yield return new WaitForSecondsRealtime(time);
        canAttack = true;
    }
}
