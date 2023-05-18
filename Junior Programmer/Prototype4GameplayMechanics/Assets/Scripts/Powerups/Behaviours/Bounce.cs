using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller of the bounce powerup behaviour.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-13
/// </para>
/// </remarks>
[RequireComponent(typeof(PlayerController))]
public class Bounce : MonoBehaviour
{
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
