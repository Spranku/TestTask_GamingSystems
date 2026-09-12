using System.Collections.Generic;
using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    private readonly Dictionary<AbilityBase, float> cooldownTimers = new Dictionary<AbilityBase, float>();

    private void Update()
    {
        /* Tick of cooldown*/
        var keys = new List<AbilityBase>(cooldownTimers.Keys);
        foreach (var ability in keys)
        {
            if (cooldownTimers[ability] > 0f) cooldownTimers[ability] -= Time.deltaTime;
        }
    }

    public bool IsOnCooldown(AbilityBase ability)
    {
        return cooldownTimers.TryGetValue(ability, out float timer) && timer > 0f;
    }

    /* Time before ready */
    public float GetCooldownRemaining(AbilityBase ability)
    {
        if (cooldownTimers.TryGetValue(ability, out float timer))
        {
            return Mathf.Max(0f, timer);
        }
        return 0f;
    }

    public bool TryActivate(AbilityBase ability)
    {
        if (IsOnCooldown(ability)) return false;

        /* Activate ability on owner (player) */
        ability.ActivateAbility(gameObject);
        cooldownTimers[ability] = ability.cooldown;
        return true;
    }
}