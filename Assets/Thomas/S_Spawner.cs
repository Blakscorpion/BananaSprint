using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Spawner : MonoBehaviour
{
    public List<GameObject> templateEntity = new List<GameObject>();
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

                Instantiate(templateEntity[Random.Range(0, templateEntity.Count)], transform.position, Quaternion.identity);
                S_SpawnerStatic.entityAmount++;
            }
        }
    }
}
