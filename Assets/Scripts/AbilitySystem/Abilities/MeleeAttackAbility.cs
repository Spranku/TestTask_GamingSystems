using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Abilities/Melee")]
public class MeleeAttackAbility : AbilityBase
{
    public float radius = 1.5f;
    public LayerMask enemyLayer;

    public override void ActivateAbility(GameObject owner)
    {
        /* One meter in front */
        const float offset = 1f;
        Vector3 center = owner.transform.position + owner.transform.forward * offset;

        /* Ask how much colliders there are right now here. 
         * Do they have realization of IDamageable interface?
         */
        var hits = Physics.OverlapSphere(center, radius, enemyLayer);
        foreach (var hit in hits)
        {
            if(hit.TryGetComponent<IDamageable>(out var target))
            {
                /* Creating new damage data by params */
                var data = new DamageData(damage, DamageType.Physical, owner, center);
                /* Send data to system */
                DamageSystem.ApplyDamage(target, data);
            }
        }
    }
}