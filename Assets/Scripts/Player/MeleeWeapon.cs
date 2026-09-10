using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class MeleeWeapon : MonoBehaviour
{
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
        Debug.Log("Hit");
        weaponPoint.localRotation = Quaternion.Euler(-90,00,0);
        StartCoroutine(ResetWeaponRotation());
    }

    IEnumerator ResetWeaponRotation()
    {
        yield return new WaitForSeconds(0.1f);
        weaponPoint.localRotation = Quaternion.identity;
    }
}
