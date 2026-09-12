using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] 
    private AbilityComponent abilityComp;
    [SerializeField] 
    private AbilityBase primaryAttack;
    [SerializeField] 
    private AbilityBase dashAbility;

    /* Hear player input and launch abilities */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            abilityComp.TryActivate(primaryAttack);

        if (Input.GetKeyDown(KeyCode.Space))
            abilityComp.TryActivate(dashAbility);
    }
}
