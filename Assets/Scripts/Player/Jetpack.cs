using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    private Transform FiringPos;
    [SerializeField] private GameObject jetpackBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        FiringPos = transform.Find("FiringPoint");
    }


    public void Fire()
    {
        Instantiate(jetpackBulletPrefab, FiringPos.position, FiringPos.rotation);
    }
}
