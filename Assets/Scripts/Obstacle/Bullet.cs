using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //variables for bullet movement
    private Rigidbody2D bulletRB;
    private float speed;
    private float bulletScale;

    //reference to game manager
    private GameManager gameManager;

    // Start is called before the first frame update
    // Gives the bullet it's speed when spawned
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();

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

    //kills player if bullet collides with player if the player does not have a shield.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement Player = collision.gameObject.GetComponent<PlayerMovement>();
            if (Player.hasShield)
            {
                Player.disableShield();
            }
            else
            {
                Destroy(collision.gameObject);
                gameManager.setPlayerDead();

            }
            Destroy(this.gameObject);
        }
    }

}
