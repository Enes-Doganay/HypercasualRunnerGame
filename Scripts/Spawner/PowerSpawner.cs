using UnityEngine;

public class PowerSpawner : Spawner
{
    private float time = 0;
    [SerializeField] UpgradeSO luck;

    private void Start()
    {
        SetSpawnCooldown(10f);
        endPosition = endObj.transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= GetSpawnTime())
        {
            time = 0;
            if (Character.Instance.start)
            {
                int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
                SpawnObject(randomSpawnPoint);
                SetSpawnTime(GetSpawnCooldown() - CalculateLuck());
            }
        }
    }
    private float CalculateLuck()
    {
        float luckValue = 0.2f * luck.level;
        if (luckValue <= 5)
            return luckValue;
        else
            return 5f; // max spawn time 5s
    }
}
