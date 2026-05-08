using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject dronePrefab;
    public GameObject tankPrefab;
    public GameObject queenPrefab;

    public float droneSpawnRate = 3f;
    public float tankSpawnRate = 15f;
    public float queenSpawnRate = 30f;
    public float spawnRadius = 15f;

    private float droneTimer;
    private float tankTimer;
    private float queenTimer;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        droneTimer += Time.deltaTime;
        tankTimer += Time.deltaTime;
        queenTimer += Time.deltaTime;

        if (droneTimer >= droneSpawnRate)
        {
            droneTimer = 0f;
            SpawnEnemy(dronePrefab);
        }

        if (tankTimer >= tankSpawnRate)
        {
            tankTimer = 0f;
            SpawnEnemy(tankPrefab);
        }

        if (queenTimer >= queenSpawnRate)
        {
            queenTimer = 0f;
            SpawnEnemy(queenPrefab);
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Vector2 spawnPosition = GetSpawnPosition();
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    Vector2 GetSpawnPosition()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float x = player.position.x + Mathf.Cos(angle) * spawnRadius;
        float y = player.position.y + Mathf.Sin(angle) * spawnRadius;
        return new Vector2(x, y);
    }
}