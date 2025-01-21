using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // shield variables
    private bool hasShield;
    private int shieldCharge;

    // called when object loads into Scene
    private void Awake()
    {
        shieldCharge = 0;
    }

    // gives player invulnerabilty shield for 3 charges.
    public void equipShield()
    {
        hasShield = true;
        shieldCharge = 3;
    }

    // Removed shield charge if player has shield otherwise kills player
    public void TakeDamage()
    {
        if (hasShield)
        {
            shieldCharge -= 1;

            if (shieldCharge > 0)
            {
                hasShield = false;
            }
        }

        Destroy(gameObject);
    }
}
