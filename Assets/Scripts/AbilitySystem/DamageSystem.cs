using System.Collections.Generic;
using UnityEngine;

public static class DamageSystem
{
    /* For stats */
    public static event System.Action<IDamageable, float> OnDamageApplied;

    /* Modifiers */
    private static readonly List<IDamageModifier> modifiers = new List<IDamageModifier>();

    public static void RegisterModifier(IDamageModifier modifier)
    {
        if (!modifiers.Contains(modifier)) modifiers.Add(modifier);
    }

    public static void UnregisterModifier(IDamageModifier modifier)
    {
        modifiers.Remove(modifier);
    }

    public static void ClearModifiers()
    {
        modifiers.Clear();
    }

    public static void ApplyDamage(IDamageable target, DamageData data)
    {
        if (target == null) return;
        if (!target.bIsAlive) return;

        /* Saving copy of clear damage */
        float finalDamage = data.DamageAmount;

        /* Check all modifiers
         * Every modifier change final damage
         */
        foreach (var modifier in modifiers)
        {
            /* Get new value of damage (afer modify)
             * Every modifier changing final damage
             */
            finalDamage = modifier.Modify(finalDamage, data, target);

            /* Do nothing */
            if (finalDamage <= 0f) break;
        }

        var finalData = data;
        finalData.DamageAmount = finalDamage;

        /* Send info to stats comp 
         * Damage for player / enemy
         */
        if (target is Component targetComponent && targetComponent.CompareTag("Player"))
            GameManager.Instance?.Stats?.RecordDamageTaken(finalData.DamageAmount);
        else
            GameManager.Instance?.Stats?.RecordDamageDealt(finalData.DamageAmount);

        Debug.Log("Apply damage from " + data.Instigator.name + " " + finalData.DamageAmount + " to " + target);

        target.TakeDamage(finalData);
    }
}
