using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    //speed of the run
    public float Speed;

    //how many seconds between spawns
    public float SpawnTime;

    public float WaitTime = 5f;

    //is playing
    bool Running;

    [Header("spawn spot z-axis")]
    public float spawnSpot = 8;

    //how many seconds before speed is added
    public float SpeedTimer = 10f;

    private int spawnedIndex = 0;


    [Header("Level objects to spawn")]
    public GameObject[] levelPrefabs;


    public LevelPrefabEntity StartEntity;


    //start the running
    public void StartRunning()
    {
        Running = true;
        StartEntity.CallWhenSpawned(Speed); //the first one to move
        StartCoroutine(WaitToSpawnObjects());

    }

    //Stop the running
    public void StopRunning()
    {
        Running = false;
    }

    //continue running
    public void ContinueRunning()
    {
        Running = true;
        StartCoroutine(Playing());
    }

    //spawn prefab
    void SpawnPrefab()
    {
        if (spawnedIndex < levelPrefabs.Length)
        {
            GameObject spawned = Instantiate(levelPrefabs[spawnedIndex], new Vector3(0, 0, spawnSpot), Quaternion.identity);

            //set speed of the prefab
            spawned.GetComponent<LevelPrefabEntity>().CallWhenSpawned(Speed);
            spawnedIndex++;
        }
    }


    //adds speed in certain time
    IEnumerator Playing()
    {
        while (Running)
        {
            yield return new WaitForSeconds(SpeedTimer);
            Speed++;

            //reduce spawntime?
        }
    }

    //coroutine for spawning prefabs
    IEnumerator SpawnPrefabs()
    {
        while (Running && spawnedIndex < levelPrefabs.Length)
        {
            if (Running)
            {
                SpawnPrefab();
            }
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    IEnumerator WaitToSpawnObjects()
    {
        yield return new WaitForSeconds(WaitTime);
        //start speed adding coroutine
        //StartCoroutine(Playing());
        StartCoroutine(SpawnPrefabs());
    }
}
