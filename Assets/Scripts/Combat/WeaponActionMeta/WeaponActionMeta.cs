using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationTrigger
{
	Swing,
	Revolver_Shot
}

public enum WeaponType {
    Melee_Weapon,
    Ranged_Weapon,
}

public class WeaponActionMeta : ScriptableObject
{
    public WeaponType type;
    public AnimationTrigger TriggerKeyword;
    public virtual void WeaponActionAttack(GameObject transform) {
        Debug.Log("This is being called");
    }
}
