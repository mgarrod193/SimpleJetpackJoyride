using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D bulletRB;
    private float speed;
    
    // Start is called before the first frame update
    // Gives the bullet it's speed when spawned
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        speed = Random.Range(-15.0f, -20.0f);
        bulletRB.velocity = new Vector2 (speed, 0);
    }

    //kills player if bullet collides with player
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

}
