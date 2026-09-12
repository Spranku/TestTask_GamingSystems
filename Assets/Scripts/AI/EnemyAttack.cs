using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] 
    private float contactDamage = 10f;
    [SerializeField] 
    private float damageCooldown = 1f;
    [SerializeField] 
    private float attackRange = 1.2f;
    [SerializeField] 
    private LayerMask playerLayer;

    private float nextDamageTime;

    private void Update()
    {
        if (Time.time < nextDamageTime) return;

        var hits = Physics.OverlapSphere(transform.position, attackRange, playerLayer);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<IDamageable>(out var player))
            {
                nextDamageTime = Time.time + damageCooldown;

                var data = new DamageData(contactDamage, DamageType.Physical, gameObject, transform.position);
                DamageSystem.ApplyDamage(player, data);
                break;
            }
        }
    }

    /* Debug only, can delete */
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, attackRange);
    //}
}