using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D jetpackBulletrb;


    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
        jetpackBulletrb = GetComponent<Rigidbody2D>();
        jetpackBulletrb.velocity = new Vector2(0, -speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameManager.IncreaseScore(collision.gameObject.GetComponent<Points>().GetPoints());
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

}
