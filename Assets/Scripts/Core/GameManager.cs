using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StatsComponent Stats { get; set; }
    public int EnemiesAlive { get; private set; }
    public int EnemiesKilled { get; private set; }
    public bool IsGameOver { get; private set; }

    /* Events for UI */
    public event Action OnVictory;
    public event Action OnDefeat;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterEnemy()
    {
        EnemiesAlive++;
    }

    public void OnEnemyKilled(GameObject enemy)
    {
        EnemiesKilled++;
        EnemiesAlive--;

        if (EnemiesAlive <= 0 && !IsGameOver)
            TriggerVictory();
    }

    public void OnPlayerDied()
    {
        if (IsGameOver) return;
        TriggerDefeat();
    }

    private void TriggerVictory()
    {
        Debug.Log("GameManager::TriggerVictory - Victory");
        IsGameOver = true;
        OnVictory?.Invoke();
    }

    private void TriggerDefeat()
    {
        Debug.Log("GameManager::TriggerVictory - Defeat");
        IsGameOver = true;
        OnDefeat?.Invoke();
    }
}
