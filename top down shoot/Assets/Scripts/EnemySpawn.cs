using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] GameObject enemyPre;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 3f;

    float spawnDist = 10f;
    Vector2 screenBounds;
    Vector2 spawnPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0, 4);
            switch (side)
            {
                case 0:
                
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDist);
                break;
                 
                 case 1:
                
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnDist);
                break;

                case 2:
                spawnPos = new Vector2(screenBounds.x + spawnDist, Random.Range(-screenBounds.y, screenBounds.x));
                break;
                case 3:
                spawnPos = new Vector2(-screenBounds.x - spawnDist, Random.Range(-screenBounds.y, screenBounds.x));
                break;
        }

        Instantiate(enemyPre, spawnPos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);

    }
}
 