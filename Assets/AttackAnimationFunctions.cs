using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationFunctions : MonoBehaviour
{
    public Weapon weapon;

    public void AttackWithWeapon() {
        weapon.ExecuteAttack();
    }
}
