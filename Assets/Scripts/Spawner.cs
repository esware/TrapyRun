using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1;

    [SerializeField] private PoolObject objectPool = null;
    [SerializeField] private int spawnCount = 15;
    [SerializeField] private int spawnDistance = 15;
    PlayerController controller;
    public int spawnedObjCounter = 0;


    void Start()
    {
        //StartCoroutine(nameof(SpawnRoutine));
        controller = FindObjectOfType<PlayerController>();


    }


    private void Update()
    {
        StartCoroutine(SpawnRoutine());
    }


    private IEnumerator SpawnRoutine()
    { 
        if (Mathf.Abs(Vector3.Distance(transform.position, controller.transform.position)) < spawnDistance)
        {
            while (spawnedObjCounter < spawnCount)
            {
                float x = Random.Range(transform.position.x - 3f, transform.position.x + 4f);
                float z = Random.Range(transform.position.z - 3f, transform.position.z + 4f);
                GameObject obj = objectPool.GetPooledObject(spawnedObjCounter % 2);
                obj.transform.position = new Vector3(x, 0, z);
                if(obj.transform.position.x < -6)
                {
                    obj.transform.rotation = Quaternion.Euler(0,90,0);
                }
                else if (obj.transform.position.x > 6)
                {
                    obj.transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                spawnedObjCounter++;
                yield return new WaitForSeconds(spawnInterval);
            }
        }

    }
}
