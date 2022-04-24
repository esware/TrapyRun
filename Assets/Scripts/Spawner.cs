using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1;

    [SerializeField] private PoolObject objectPool = null;
    [SerializeField] private int selectEnemy = 0;
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int enemyCounter = 0;


    void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }
    private IEnumerator SpawnRoutine()
    {
        while (enemyCounter < enemyCount)
        {
            float x = Random.Range(transform.position.x-3f,  transform.position.x+3f);
            float z = Random.Range( transform.position.z+3f,  transform.position.z+3f);
            
            GameObject obj = objectPool.GetPooledObject(selectEnemy++%2);

            obj.transform.position = new Vector3(x, 1, z);
            enemyCounter++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
