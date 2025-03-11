using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    //variables for powerup movement
    private Rigidbody2D powerUpRb;
    private float speed;


    // Start is called before the first frame update
    // Gives the powerup it's speed when spawned
    void Start()
    {

        powerUpRb = GetComponent<Rigidbody2D>();

        //controls powerup speed
        speed = Random.Range(-6.0f, -4.0f);
        powerUpRb.velocity = new Vector2(speed, 0);


        // Destroy Object after 15s
        Destroy(gameObject, 15);
    }

    //if collision occurs with player give player the shield and destroy the powerup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().enableShield();
            Destroy(this.gameObject);
        }
    }
}
