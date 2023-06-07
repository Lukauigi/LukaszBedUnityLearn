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
    // Attributes
    [SerializeField, Tooltip("The movement rate of the missile's position."), Range(1f, 15f)]
    private float _movementSpeed = 6f;
    [SerializeField, Tooltip("The rotation rate when the missile rotates."), Range(1f, 15f)]
    private float _rotationSpeed = 4f;
    [SerializeField, Tooltip("The time before the missile will destroy itself."), Range(1f, 15f)]
    private float _selfdestructTime = 5f;

    private float _knockback;
    private bool _isSeekingTarget = false;

    // Ref(s) to other game objects
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
            FindTarget();
        }

        StartCoroutine(SelfDestructCountdown());
        SeekTarget();
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
    /// Finds the nearest enemy target in relation to the missile itself.
    /// </summary>
    private void FindTarget()
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

    /// <summary>
    /// Homes toward the closest enemy target.
    /// </summary>
    private void SeekTarget()
    {
        MoveMissileTowardsTarget();
        RotateMissileTowardsTarget();
        if (!_targetEnemy && _isSeekingTarget)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Moves the missile's position towards the enemy target's position.
    /// </summary>
    private void MoveMissileTowardsTarget()
    {
        float movementStep = _movementSpeed * Time.deltaTime; // calc distance to move
        if (_targetEnemy)
        {
            
            Transform homeTarget = _targetEnemy.transform;
            transform.position = Vector3.MoveTowards(transform.position, 
                homeTarget.position, movementStep);
            transform.position = new Vector3(transform.position.x, 
                Missile.YPositionOffset, transform.position.z);
        }        
    }

    /// <summary>
    /// Rotates the missile so that the front of the missile is facing the enemy target.
    /// </summary>
    private void RotateMissileTowardsTarget()
    {
        float rotationStep = _rotationSpeed * Time.deltaTime;
        if (_targetEnemy)
        {
            Transform homeTarget = _targetEnemy.transform;
            Vector3 homeTargetDirection = homeTarget.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, 
                homeTargetDirection, rotationStep, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
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

    /// <summary>
    /// Waits until the missile is set to self-destruct.
    /// </summary>
    /// <returns>A second, waiting for self-destruct time.</returns>
    private IEnumerator SelfDestructCountdown()
    {
        yield return new WaitForSeconds(_selfdestructTime);
        Destroy(gameObject);
    }
    
}
