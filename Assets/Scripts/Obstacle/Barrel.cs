using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D objRb;
    [SerializeField] float rotationSpeed = 50;
    [SerializeField] Vector2 speed = new Vector2(-10f, 0);
    

    // Start is called before the first frame update
    void Start()
    {
        objRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        objRb.velocity = speed;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" )
        {
            Destroy(collision.gameObject);
        }
    }
}
