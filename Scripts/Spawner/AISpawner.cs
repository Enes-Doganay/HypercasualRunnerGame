using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : Spawner
{
    [SerializeField]
    Material[] myMaterial;
    public Material[] materials;
    public Transform[] aISpawnPoint;
    public Transform[] aITransform;
    public GameObject aI;
    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            SpawnObject(i);
        }
    }
    protected override void SpawnObject(int i)
    {
        nextSpawnPoint = new Vector3(aISpawnPoint[i].position.x, aI.transform.position.y, aISpawnPoint[i].position.z);
        GameObject temp = Instantiate(aI, nextSpawnPoint, Quaternion.identity);
        SetMaterial(temp, 0, materials[Random.Range(0, materials.Length)]);
        SetMaterial(temp, 1, materials[Random.Range(0, materials.Length)]);
        aITransform[i] = temp.transform;
    }
    void SetMaterial(GameObject obj,int matNumber,Material mat) 
    {
        SkinnedMeshRenderer renderer = obj.GetComponentInChildren<SkinnedMeshRenderer>();
        Material[] mats = renderer.materials;
        mats[matNumber] = mat;
        renderer.materials = mats;
    }
}
