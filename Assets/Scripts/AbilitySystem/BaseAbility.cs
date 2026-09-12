using UnityEngine;

public abstract class AbilityBase : ScriptableObject
{
    public string abilityName = "Ability";
    public float cooldown = 1f;
    public float damage = 10f;

    public abstract void ActivateAbility(GameObject owner);
}
