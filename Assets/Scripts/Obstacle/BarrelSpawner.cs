using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrellSpawner : MonoBehaviour
{

    [SerializeField] GameObject barrelPrefab;
    private float spawnTimer;
    private Coroutine startSpawn;

    // Start is called before the first frame update
    void Start()
    {
        startSpawn = StartCoroutine(StartSpawn());
    }



    private IEnumerator StartSpawn()
    {
        while (true)
        {
            spawnTimer = Random.Range(1.0f, 5.0f);
            yield return new WaitForSeconds(spawnTimer);
            Instantiate(barrelPrefab, transform.position, transform.rotation);
        }
    }
}
