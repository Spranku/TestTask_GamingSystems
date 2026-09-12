using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] 
    private float maxHealth = 100f;

    public float Current { get; private set; }
    public float Max => maxHealth;
    public bool bIsAlive => Current > 0f;

    /* Events  */
    public event Action<float, float> OnHealthChanged; 
    public event Action<DamageData> OnDamageTaken;
    public event Action OnDeath;

    private void Awake()
    {
        Current = maxHealth;
    }

    public void TakeDamage(DamageData damage)
    {
        if (!bIsAlive) return;

        Current = Mathf.Max(0f, Current - damage.DamageAmount);
        OnDamageTaken?.Invoke(damage); // for VFX and sound
        OnHealthChanged?.Invoke(Current, maxHealth); // for UI

        /* Final death*/
        if (Current <= 0f)
        {
            OnDeath?.Invoke();

            /* Choice kill or dead */
            if (CompareTag("Player"))
            {
                GameManager.Instance?.Stats?.RecordDeath();
                GameManager.Instance?.OnPlayerDied();
            }
            else
            {
                GameManager.Instance?.Stats?.RecordKill();
                GameManager.Instance?.OnEnemyKilled(gameObject);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}