using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour, IObserver
{
    [SerializeField] 
    private StatsComponent statsComponent;

    [SerializeField] 
    private Text appliedDamageText;
    [SerializeField] 
    private Text gettingDamageText;
    [SerializeField] 
    private Text battleTimeText;
    [SerializeField] 
    private Text totalKillsText;
    [SerializeField] 
    private Text totalDeadsText;

    private void OnEnable()
    {
        if (statsComponent != null) statsComponent.Attach(this);
    }

    private void OnDisable()
    {
        if (statsComponent != null)
            statsComponent.Detach(this);
    }

    public void OnNotify(StatsData data)
    {
        if (appliedDamageText != null)
            appliedDamageText.text = $"Damage dealt: {data.appliedDamage:F1}";

        if (gettingDamageText != null)
            gettingDamageText.text = $"Damage received: {data.gettingDamage:F1}";

        if (battleTimeText != null)
            battleTimeText.text = $"Time of battle: {data.battleTime:F1}s";

        if (totalKillsText != null)
            totalKillsText.text = $"Total kills: {data.totalKills}";

        if (totalDeadsText != null)
            totalDeadsText.text = $"Total deaths: {data.totalDeads}";
    }

    private void Update()
    {
        if (battleTimeText != null && statsComponent != null)
            battleTimeText.text = $"Time: {statsComponent.CurrentStats.battleTime:F1}s";
    }
}
