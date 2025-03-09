using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    //variables for controlling barrell movement
    private Rigidbody2D objRb;
    [SerializeField] float rotationSpeed = 50;
    [SerializeField] Vector2 speed = new Vector2(-10f, 0);
    
    //reference to game manager game object
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        objRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        objRb.velocity = speed;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }


    //kills player when object colllides with player and sets the player alive status to dead
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" )
        {
            Destroy(collision.gameObject);
            gameManager.setPlayerDead();
        }
    }
}
