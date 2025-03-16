using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    //variables for controlling speed and position
    [SerializeField] Vector3 resetPos;
    [SerializeField] float maxPos;
    [SerializeField] float moveSpeed;

    private void Update()
    {
        transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        if (transform.position.x < maxPos)
        {
            transform.position = resetPos;
        }
    }


}
