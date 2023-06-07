using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of enemy behaviours.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-09
/// </para>
/// </remarks>
public class Enemy : MonoBehaviour
{
    // Attributes
    [SerializeField, Tooltip("The movement speed.")]
    private float _speed = 2.5f;
    [SerializeField, Tooltip("Is the enemy a boss enemy.")]

    // For the boss
    private bool _isBoss = false;
    private float _bossKnockback = 1.25f;

    // Ref(s) to attached component(s)
    private Rigidbody _enemyRb;

    // Ref(s) to other GameObject(s)
    private GameObject _player;

    /// <inheritdoc />
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    /// <inheritdoc />
    void Update()
    {
        // normalized to not have the movement over greater distances faster
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        lookDirection.y = 0f;

        _enemyRb.AddForce(lookDirection * _speed);
    }

    /// <inheritdoc />
    private void OnCollisionEnter(Collision collision)
    {
        if (_isBoss && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 oppositeDirection = (otherRb.transform.position - transform.position);
            otherRb.AddForce(oppositeDirection * _bossKnockback, ForceMode.Impulse);
        }
    }
}
