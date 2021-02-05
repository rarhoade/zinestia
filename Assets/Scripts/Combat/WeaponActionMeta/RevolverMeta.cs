using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/WeaponMeta/Revolver Meta")]
public class RevolverMeta : RangedWeaponActionMeta
{
    public GameObject revolverBullet;
    public float attackCooldown;
    public override void WeaponActionAttack(GameObject t)
    {
        base.WeaponActionAttack(t);
        var bullet = Instantiate(
            revolverBullet, 
            t.transform.position, 
            Quaternion.Euler(t.transform.parent.rotation.eulerAngles)
        );
        Destroy(bullet, 1.0f);
    }
}
