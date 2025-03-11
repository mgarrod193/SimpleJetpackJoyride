using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrellSpawner : MonoBehaviour
{
    //variables for controlling spawn of barrells
    [SerializeField] GameObject barrelPrefab;
    [SerializeField] float lowerSpawnTime;
    [SerializeField] float upperSpawnTime;
    private float spawnTimer;
    private Coroutine startSpawn;

    // Start is called before the first frame update
    void Start()
    {
        startSpawn = StartCoroutine(StartSpawn());
    }


    // spawns a barrel based on the random value generated for the spawnTimer
    private IEnumerator StartSpawn()
    {
        while (true)
        {
            spawnTimer = Random.Range(lowerSpawnTime, upperSpawnTime);
            yield return new WaitForSeconds(spawnTimer);
            Instantiate(barrelPrefab, transform.position, transform.rotation);
        }
    }
}
