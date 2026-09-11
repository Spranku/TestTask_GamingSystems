using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] 
    private Animator weaponAnimator;
    [SerializeField]
    private CustomInput customInput;
    [SerializeField]
    private Transform weaponPoint;
    [SerializeField]
    private float hitRate = 0.15f;
    [SerializeField]
    private float swingSpeed = 1.0f;
    [SerializeField]
    private float clearDamage = 10.0f;
    [SerializeField]
    private float damageMultiplier = 1.0f;
    [SerializeField] 
    private Vector3 hitboxOffset = new Vector3(0f, 0f, 1f);
    [SerializeField] 
    private LayerMask enemyLayer;
    [SerializeField] 
    private float hitRadius = 1.5f;

    private float nextHitTime;

    // Update is called once per frame
    void Update()
    {
        if (!customInput.HitPressed || Time.time < nextHitTime) return;

        nextHitTime = Time.time + hitRate;

        Hit();
    }

    void Hit()
    {
        weaponAnimator.SetTrigger("Hit0");

        Vector3 center = weaponPoint.position + weaponPoint.forward * hitboxOffset.z;
        Collider[] hits = Physics.OverlapSphere(center, hitRadius, enemyLayer);

        foreach (var hit in hits)
        {
            Debug.Log(hit.gameObject.name);
        }


        weaponAnimator.SetTrigger("Idle");
    }

    private void OnDrawGizmosSelected()
    {
        if (weaponPoint == null) return;

        Gizmos.color = Color.red;
        Vector3 center = weaponPoint.position + weaponPoint.forward * hitboxOffset.z;
        Gizmos.DrawWireSphere(center, hitRadius);
    }

}
