using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Modifiers/Armor")]
public class ArmorModifier : ScriptableObject, IDamageModifier
{
    /* 30% of armor */
    public float damageReduction = 0.3f; 

    public float Modify(float damage, DamageData data, IDamageable target)
    {
        /* if true - damage ignores armomr */
        if (data.TypeOfDamage == DamageType.True) return damage;
        return damage * (1f - damageReduction);
    }
}
