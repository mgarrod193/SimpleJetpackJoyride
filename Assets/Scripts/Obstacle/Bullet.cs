using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D bulletRB;
    private float speed;
    private float bulletScale;
    // Start is called before the first frame update
    // Gives the bullet it's speed when spawned
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();

        //controls buttlet speed
        speed = Random.Range(-20.0f, -12.0f);
        bulletRB.velocity = new Vector2 (speed, 0);

        //constrols bullet size
        bulletScale = Random.Range(3, 4);
        transform.localScale = new Vector3(bulletScale, bulletScale, transform.localScale.z);

        // Destroy Object after 5s
        Destroy(gameObject, 5);
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
