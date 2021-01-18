using UnityEngine;
using Kryz.CharacterStats;

public class BloodyMess : Perk
{
    public BloodyMess(){
        this.Name = "Bloody Mess";
        this.Cases.Add(PerkTypes.WeaponDamageModifier);
    }

    public override void ApplyPerk(PerkTypes perkContext, GameObject contextObj)
    {
        base.ApplyPerk(perkContext, contextObj);
        if(perkContext == PerkTypes.WeaponDamageModifier) {
            contextObj.GetComponent<Weapon>().ApplyDamageMultiplier(1.05f);
        }
    }
}
