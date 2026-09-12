using UnityEngine;

public class ArenaTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private int enemyCount = 4;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private float spawnDelay = 0.5f;

    private const string playerTag = "Player";
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        /* Launch check time of battle for stats comp */
        var stats = other.GetComponent<StatsComponent>();
        if (stats == null) stats = other.GetComponentInParent<StatsComponent>();
        stats?.StartBattle();

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (enemyPrefab == null) return;

        for (int i = 0; i < enemyCount; ++i)
        {
            Vector3 spawnPos = GetSpawnPosition(i);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            GameManager.Instance?.RegisterEnemy();
        }
    }

    private Vector3 GetSpawnPosition(int index)
    {
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            var point = spawnPoints[index % spawnPoints.Length];
            return point != null ? point.position : transform.position;
        }

        return Vector3.zero;
    }
}
