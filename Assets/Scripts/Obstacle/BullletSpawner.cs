using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullletSpawner : MonoBehaviour
{
    // References to Objects in scene
    private Transform upperLimit;
    private Transform lowerLimit;
    [SerializeField] GameObject bulletPrefab;

    // variables for controlling spawnrate and position
    private Coroutine bulletSpawnCoroutine;
    private float spawnTime;
    private Vector2 spawnPos;

    // connects game objects 
    void Start()
    {
        upperLimit = transform.Find("UpperLimit");
        lowerLimit = transform.Find("LowerLimit");
        bulletSpawnCoroutine = StartCoroutine(BulletSpawnCourtine());
    }


    // generates a random position and spwn time within given values and spawns a bullet
    private IEnumerator BulletSpawnCourtine()
    {
        while (true)
        {
            spawnTime = Random.Range(0.3f, 1.5f);
            spawnPos = new Vector2(transform.position.x, Random.Range(upperLimit.position.y, lowerLimit.position.y));
            yield return new WaitForSeconds(spawnTime);
            Instantiate(bulletPrefab, spawnPos, transform.rotation);
        }
    }
}
