using UnityEngine;

public class CombatBootstrap : MonoBehaviour
{
    [SerializeField]
    private CritModifier critModifier;
    [SerializeField]
    private ArmorModifier armorModifier;
    [SerializeField]
    private bool modifiersEnabled;

    private void OnEnable()
    {
        /* Uncomment it for check modifiers works */
        if (modifiersEnabled)
        {
            if (critModifier != null) DamageSystem.RegisterModifier(critModifier);
            if (armorModifier != null) DamageSystem.RegisterModifier(armorModifier);
        }
    }

    private void OnDisable()
    {
        if (critModifier != null) DamageSystem.UnregisterModifier(critModifier);
        if (armorModifier != null) DamageSystem.UnregisterModifier(armorModifier);
    }

    /* TODO */
    //private void OnDestroy() => DamageSystem.ClearModifiers();

    private void OnDestroy()
    {
        DamageSystem.ClearModifiers();
    }
}
