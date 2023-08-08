using UnityEngine;

public class ObstacleSpawner : Spawner
{
    public GameObject winPrefab;
    public int mainObstacleNumber;
    private int count = 0;

    private float time = 0.0f;
    private void Start()
    {
        mainObstacleNumber = CalculateObstacle();
        endPosition = endObj.transform.position;
        SetSpawnCooldown(1f);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= GetSpawnTime() && count < mainObstacleNumber)
        {
            time = 0;
            SetSpawnTime(GetSpawnCooldown());
            if (Character.Instance.start)
            {
                SpawnObject(0);
                count++;
                if (count == mainObstacleNumber - 1)
                {
                    nextSpawnPoint = new Vector3(spawnPoint[0].position.x, winPrefab.transform.position.y, Character.Instance.transform.position.z + playerOffsetZ);
                    Instantiate(winPrefab, nextSpawnPoint, Quaternion.identity);
                }
            }
        }
    }

    private int CalculateObstacle()
    {
        return mainObstacleNumber + (2 * Character.Instance.GetLevel());
    }
}
