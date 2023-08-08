using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public Character Character;

    public GameObject[] spawnObject;
    public GameObject road;
    public GameObject endObj;
    
    public Transform[] spawnPoint;
    
    public Vector3 endPosition;
    public Vector3 nextSpawnPoint;
    
    public float playerOffsetZ;
    
    private float spawnTime = 0f;
    private float spawnCooldown = 1f;
    private float destroyTime = 9f;

    virtual protected void SpawnObject(int randomSpawnPoint)
    {
        int randomObj = Random.Range(0, spawnObject.Length);
        nextSpawnPoint = new Vector3(spawnPoint[randomSpawnPoint].position.x,spawnObject[randomObj].transform.position.y, Character.Instance.transform.position.z + playerOffsetZ);
        SpawnRoad();
        GameObject spawnObj = Instantiate(spawnObject[randomObj], nextSpawnPoint, Quaternion.identity);
        Destroy(spawnObj, destroyTime);
    }

    virtual protected void SetSpawnTime(float spawnTimeCooldown)
    {
        spawnTime = spawnTimeCooldown;
    }
    virtual protected float GetSpawnTime()
    {
        return spawnTime;
    }
    virtual protected void SetSpawnCooldown(float spawnCooldownTime)
    {
        spawnCooldown = spawnCooldownTime;
    }
    virtual protected float GetSpawnCooldown()
    {
        return spawnCooldown;
    }
    virtual protected void SpawnRoad()
    {
        if (nextSpawnPoint.z >= endPosition.z)
        {
            GameObject SpawnRoad = Instantiate(road, endPosition, Quaternion.identity);
            endPosition = SpawnRoad.transform.GetChild(0).GetChild(3).position;
        }
    }

}
