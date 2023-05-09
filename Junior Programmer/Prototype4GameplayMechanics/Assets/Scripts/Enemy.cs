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

    // Ref(s) to attached component(s)
    private Rigidbody _enemyRb;

    // Ref(s) to other GameObject(s)
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // normalized to not have the movement over greater distances faster
        _enemyRb.AddForce((_player.transform.position - transform.position).normalized * _speed);
    }
}
