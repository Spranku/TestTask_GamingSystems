using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Modifiers/Crit")]
public class CritModifier : ScriptableObject, IDamageModifier
{
    public float critChance = 0.2f;
    public float critMultiplier = 2f;

    public float Modify(float damage, DamageData data, IDamageable target)
    {
        if (Random.value < critChance)
        {
            Debug.Log("CritModifier::Modify() - CRIT!");
            return damage * critMultiplier;
        }
        return damage;
    }
}