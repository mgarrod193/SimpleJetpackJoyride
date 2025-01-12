using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player movement and jetpack Variables
    private Vector2 jetpackPower = new Vector2(0f, 500f);
    private bool jetpackUsable = true;
    private float jetpackCooldown = 0.5f;
    private Coroutine jetpackCooldownCoroutine;

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
            //adds upwards moment to player and starts cooldown courtine
            playerRb.AddForce(jetpackPower);
            jetpackCooldownCoroutine = StartCoroutine(JetpackCooldownCoroutine());
        }
    }


    // Courtine to manage the jetpack cooldown to prevent it from being spammed
    private IEnumerator JetpackCooldownCoroutine()
    {
        jetpackUsable = false;
        yield return new WaitForSeconds(jetpackCooldown);
        jetpackUsable = true;
    }
}
