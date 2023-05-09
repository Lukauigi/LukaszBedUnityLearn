using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller of player interactions.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-09
/// </para>
/// </remarks>
public class PlayerController : MonoBehaviour
{
    // Attributes
    [SerializeField, Tooltip("The movement speed of the player.")]
    private float _speed = 5f;

    // Ref(s) to attached component(s)
    private Rigidbody _playerRb;

    // Ref(s) to other GameObject(s)
    private GameObject _focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        // Use the focal point's local forward direction
        _playerRb.AddForce(_speed * forwardInput * _focalPoint.transform.forward);
    }
}
