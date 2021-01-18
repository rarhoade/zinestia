using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerkTypes {
    DamageCalculation,
    EnemyDeath,
    WeaponDamageModifier,
};

public class Perk {
    // Start is called before the first frame update
    public string Name;
    public List<PerkTypes> Cases;

    public Perk() {
        Cases = new List<PerkTypes>();
    }

    public virtual void ApplyPerk(PerkTypes perkContext, GameObject contextObj) {
        Debug.Log("Applying Perk: " + this.Name + " to " + contextObj.name);
    }
}
