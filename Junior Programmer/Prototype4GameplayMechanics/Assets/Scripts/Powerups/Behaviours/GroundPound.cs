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
    public static float AirTime = 0.7f;
    public static float VerticalMoveSpeed = 13f;
    public static float PushForceRadius = 20f;

    // Instance Attributes
    private bool _isGroundPounding = false;
    private float _pushForce;

    // Ref(s) to attached components
    private Rigidbody _playerRb;

    // Public Access Fields
    /// <summary>
    /// Indicates whether the ground pound action is being performed.
    /// </summary>
    public bool IsGroundPounding { get { return _isGroundPounding; } }

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
        _playerRb.velocity = new Vector3(0f, 0f, 0f);
        float floorYPosition = transform.position.y;
        float jumpTime = Time.time + AirTime;

        // Move player up for the duration of its air time
        while(Time.time < jumpTime)
        {
            _playerRb.velocity = new Vector3(0f, VerticalMoveSpeed, 0f);
            yield return null;
        }

        // Move player down until they hit the floor
        while(transform.position.y > floorYPosition)
        {
            _playerRb.velocity = new Vector3(0f, -VerticalMoveSpeed * 2, 0f);
            yield return null;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Push nearby enemies away
        foreach (GameObject enemy in enemies)
        {
            if (enemy)
            {
                enemy.GetComponent<Rigidbody>().AddExplosionForce(_pushForce, transform.position,
                    PushForceRadius, 0f, ForceMode.Impulse);
            }
        }

        _isGroundPounding = false;
    }
}
