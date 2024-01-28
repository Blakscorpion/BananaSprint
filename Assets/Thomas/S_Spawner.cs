using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Spawner : MonoBehaviour
{
    public GameObject entityPrefab;
    public float minSpawnInterval = 3f;
    public float maxSpawnInterval = 5f;

    void Start()
    {
        StartCoroutine(SpawnEntities());
    }

    IEnumerator SpawnEntities()
    {
        while (true)
        {
            if(S_SpawnerStatic.entityAmount < 150)
            {
                float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(spawnInterval);

                Instantiate(entityPrefab, transform.position, Quaternion.identity);
                S_SpawnerStatic.entityAmount++;
            }
        }
    }
}
