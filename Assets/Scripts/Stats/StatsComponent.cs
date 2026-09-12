using UnityEngine;

public class StatsComponent : MonoBehaviour 
{
    private readonly Subject subject = new Subject();
    private StatsData currentStats = StatsData.Empty;
    private float battleStartTime;

    public StatsData CurrentStats => currentStats;

    private void OnEnable()
    {
        DamageSystem.OnDamageApplied += HandleDamage;
    }

    private void OnDisable()
    {
        DamageSystem.OnDamageApplied -= HandleDamage;
    }

    private void HandleDamage(IDamageable target, float amount)
    {
        if (target is Health health && health.CompareTag("Player"))
            RecordDamageTaken(amount);
        else
            RecordDamageDealt(amount);
    }

    private void Start()
    {
        battleStartTime = Time.time;
        /* Init stats comp in game manager */
        GameManager.Instance.Stats = this;
    }

    private void Update()
    {
        currentStats.battleTime = Time.time - battleStartTime;
    }

    /* Binds */
    public void Attach(IObserver observer) => subject.AddObserver(observer);
    public void Detach(IObserver observer) => subject.RemoveObserver(observer);

    public void RecordDamageDealt(float amount)
    {
        currentStats.appliedDamage += amount;
        subject.Notify(currentStats);
    }

    public void RecordDamageTaken(float amount)
    {
        currentStats.gettingDamage += amount;
        subject.Notify(currentStats);
    }

    public void RecordKill()
    {
        currentStats.totalKills++;
        subject.Notify(currentStats);
    }

    public void RecordDeath()
    {
        currentStats.totalDeads++;
        subject.Notify(currentStats);
    }

    private void OnDestroy()
    {
        subject.ClearObservers();
    }
}
