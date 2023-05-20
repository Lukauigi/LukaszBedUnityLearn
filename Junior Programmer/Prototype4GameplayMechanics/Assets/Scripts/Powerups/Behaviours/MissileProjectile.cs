using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of the missile projectile.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-18
/// </para>
/// <para>
/// Source(s): 
/// <list type="bullet">
///     <item>https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html</item>
///     <item>https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html</item>
/// </list>
/// </para>
/// </remarks>
public class MissileProjectile : MonoBehaviour
{
    [SerializeField, Tooltip("The movement rate of the missile's position."), Range(1f, 15f)]
    private float _movementSpeed = 6f;
    [SerializeField, Tooltip("The rotation rate when the missile rotates."), Range(1f, 15f)]
    private float _rotationSpeed = 4f;
    private float _knockback;
    private bool _isSeekingTarget = false;
    private GameObject _targetEnemy;

    /// <inheritdoc />
    private void Start()
    {
        _knockback =
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().CurrentPowerup.Knockback;
    }

    /// <inheritdoc />
    void Update()
    {
        if (!_isSeekingTarget)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 0)
            {
                //get delta distance b/w enemies & player
                float distanceApart;
                float shortestDistance = Vector3.Distance(transform.position, 
                    enemies[0].transform.position);
                GameObject closestEnemy = enemies[0];

                for (int i = 1; i < enemies.Length; i++)
                {
                    distanceApart = Vector3.Distance(transform.position, enemies[i].transform.position);
                    if (distanceApart < shortestDistance)
                    {
                        shortestDistance = distanceApart;
                        closestEnemy = enemies[i];
                    }
                }

                _targetEnemy = closestEnemy;
                _isSeekingTarget = true;
            }
        }
        else
        {
            //home to nearest enemy
            float movementStep = _movementSpeed * Time.deltaTime; // calc distance to move
            Transform homeTarget = _targetEnemy.transform;
            transform.position = Vector3.MoveTowards(transform.position, homeTarget.position, movementStep);
            transform.position = new Vector3(transform.position.x, Missile.YPositionOffset, transform.position.z);

            //rotate missile towards other object
            float rotationStep = _rotationSpeed * Time.deltaTime;
            Vector3 homeTargetDirection = homeTarget.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, homeTargetDirection, rotationStep, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }        
    }

    /// <inheritdoc />
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ApplyKnockback(other.attachedRigidbody);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Pushes the other GameObject away from the missile.
    /// </summary>
    /// <param name="otherRb">The rigidbody to push away.</param>
    private void ApplyKnockback(Rigidbody otherRb)
    {
        // Gets direction away from the player
        Vector3 awayFromMissile = (otherRb.transform.position - transform.position);

        otherRb.AddForce(awayFromMissile * _knockback,
            ForceMode.Impulse);
    }
    
}
