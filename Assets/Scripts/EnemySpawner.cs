using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeToSpawn = 10;
    public int enemiesToSpawn = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    // Update is called once per frame
    void Update()
    {
       // HandleSpawning();
    }

    

    IEnumerator SpawnEnemyWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawn);
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)); 
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
