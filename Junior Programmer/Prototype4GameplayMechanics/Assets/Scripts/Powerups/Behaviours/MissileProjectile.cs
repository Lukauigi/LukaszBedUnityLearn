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
/// </remarks>
public class MissileProjectile : MonoBehaviour
{
    [SerializeField, Tooltip("Speed in the missile moves."), Range(1f, 15f)]
    private float _speed = 6f;

    /// <inheritdoc />
    void Update()
    {
        //find all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //get delta distance b/w enemies & player
        float distanceApart;
        float shortestDistance = Vector3.Distance(transform.position, enemies[0].transform.position);
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

        //home to nearest enemy
        float step = _speed * Time.deltaTime; // calc distance to move
        Transform homeTarget = closestEnemy.transform;
        transform.position = Vector3.MoveTowards(transform.position, homeTarget.position, step);

        //rotate missile towards other object
        /*
        Vector3 homeTargetDirection = homeTarget.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, homeTargetDirection, step, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        */
    }
}
