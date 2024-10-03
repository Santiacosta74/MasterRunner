using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Transform[] spawnPoints;

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnObstacle();
            timer = spawnInterval;
        }
    }

    private void SpawnObstacle()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(obstaclePrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
