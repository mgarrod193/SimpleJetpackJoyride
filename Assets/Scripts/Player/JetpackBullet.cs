using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D jetpackBulletrb;

    // Start is called before the first frame update
    void Start()
    {
        jetpackBulletrb = GetComponent<Rigidbody2D>();
        jetpackBulletrb.velocity = new Vector2(0, -speed);
    }

}
