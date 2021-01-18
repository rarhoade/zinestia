using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RangedWeapon : Weapon
{
    // Start is called before the first frame update
    CinemachineImpulseSource source;
    public GameObject Projectile;
    public Transform FirePoint;
    void Start()
    {
        source = GetComponent<CinemachineImpulseSource>();
    }

    public override void Attack()
    {
        if(canAttack) {
            GetComponent<Animator>().SetTrigger("Attack");
            StartCoroutine("AttackCooldown", CooldownTime);
            source.GenerateImpulse();
            var bullet = Instantiate(Projectile, FirePoint.position, Quaternion.Euler(transform.parent.rotation.eulerAngles));
            Destroy(bullet, 1.0f);
        }
    }

}
