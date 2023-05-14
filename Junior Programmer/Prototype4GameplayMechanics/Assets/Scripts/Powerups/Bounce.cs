using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Bounce : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    /// <inheritdoc />
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            // Gets direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * 
                gameObject.GetComponent<PlayerController>().CurrentPowerup.Knockback, 
                ForceMode.Impulse);
        }
    }
}
