using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of the ground pound powerup.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-24
/// </para>
/// </remarks>
[RequireComponent(typeof(PlayerController))]
public class GroundPound : MonoBehaviour
{
    // Static Attributes
    public static float AirTime = 1f;
    public static float VerticalMoveSpeed = 20f;
    public static float PushForceRadius = 20f;

    // Instance Attributes
    private bool _isGroundPounding = false;
    public float _pushForce;

    //Ref(s) to attached components
    private Rigidbody _playerRb;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _pushForce = GetComponent<PlayerController>().CurrentPowerup.Knockback;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isGroundPounding)
        {
            print("ground pound");
            StartCoroutine(GroundPoundAction());
        }
    }

    /// <summary>
    /// Performs the ground pound powerup attack.
    /// </summary>
    /// <returns>Nothing.</returns>
    private IEnumerator GroundPoundAction()
    {
        _isGroundPounding = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float floorYPosition = transform.position.y;

        float jumpTime = Time.time + AirTime;

        // Move player up for the duration of its air time
        while(Time.time < jumpTime)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, VerticalMoveSpeed);
            yield return null;
        }

        // Move player down until they hit the floor
        while(transform.position.y > floorYPosition)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, -VerticalMoveSpeed * 2);
            yield return null;
        }

        // Push nearby enemies away
        if (enemies.Length != 0)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Rigidbody>().AddExplosionForce(_pushForce, transform.position,
                    PushForceRadius, 0f, ForceMode.Impulse);
            }
        }

        _isGroundPounding = false;
    }
}
