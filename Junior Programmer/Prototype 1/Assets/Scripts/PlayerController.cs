using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The bridge between the player & their character.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-03
/// </summary>
public class PlayerController : MonoBehaviour
{

    // Private vars
    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float _turnSpeed = 24.0f;
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _forwardInput;

    // Public fields
    public float Speed { get { return _speed; } }
    public float TurnSpeed { get { return _turnSpeed; } }
    public float HorizontalInput { get { return _horizontalInput; } }
    public float ForwardInput { get { return _forwardInput; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the input when the player presses the cardinal arrow keys
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward or backward

        // Gets the transform component of the current object & use the translate method to move the vehicle
        // Vector3.forward is a cleaner way to use transform.Translate(0, 0, 1);

        // Use deltatime to move the vehicle every second instead of frames that could be variable on different users' devices
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);

        // Move the vehicle to the right or left

        // transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horizontalInput);
        // using this code above will make the vehicle visually laterally. Not realistic looking.

        // Use Rotate method to turn the vehicle more realistically. Done by pivoting the object's rotation y axis
        transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
    }
}
