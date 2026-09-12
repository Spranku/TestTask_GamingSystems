using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour, IObserver
{
    [SerializeField] 
    private StatsComponent statsComponent;

    [Header("Meta screen")]
    [SerializeField]
    private GameObject ResultPanel;
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private Button menuButton;

    [Header("Stats texts")]
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

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnVictory += HandleVictory;
            GameManager.Instance.OnDefeat += HandleDefeat;
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnVictory -= HandleVictory;
            GameManager.Instance.OnDefeat -= HandleDefeat;
        }
    }

    private void HandleVictory() => ShowResult("VICTORY!");
    private void HandleDefeat() => ShowResult("DEFEAT");

    public void ShowResult(string message)
    {
        if (resultText != null) resultText.text = message;
        if (ResultPanel != null) ResultPanel.SetActive(true);
    }

    private void OnEnable()
    {
        if (statsComponent != null) statsComponent.Attach(this);
        if (ResultPanel) ResultPanel.SetActive(false);

        /* Button binds */
        if (retryButton != null) retryButton.onClick.AddListener(OnRetryClick);
        if (menuButton != null) menuButton.onClick.AddListener(OnMenuClick);
    }

    private void OnDisable()
    {
        if (statsComponent != null)
            statsComponent.Detach(this);

        if (ResultPanel) ResultPanel.SetActive(false);

        /* unbinds */
        if (retryButton != null) retryButton.onClick.RemoveListener(OnRetryClick);
        if (menuButton != null) menuButton.onClick.RemoveListener(OnMenuClick);
    }

    private void OnRetryClick() { SceneManager.LoadScene("GameLevel"); }
    private void OnMenuClick() { SceneManager.LoadScene("MainMenu");}

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
