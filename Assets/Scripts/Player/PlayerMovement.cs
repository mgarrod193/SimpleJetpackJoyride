using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player movement Variables
    private Vector2 jetpackPower = new Vector2(0f, 500f);
    private bool jetpackUsable = true;
    private float jetpackCooldown = 0.2f;

    // Player component Variables
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    // connects variables with relevent component
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    // applies constant gravity force to player
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && jetpackUsable)
        {
            playerRb.AddForce(jetpackPower);
        }
    }
}
