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
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input when the player presses left or right arrow keys
        _horizontalInput = Input.GetAxis("Horizontal");
        // Get the input when the player presses up or down arrow keys
        _forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        // Gets the transform component of the current object & use the translate method to move the vehicle
        // Vector3.forward is a cleaner way to use transform.Translate(0, 0, 1);
        // Use deltatime to move the vehicle every second instead of frames that could be variable on different users' devices
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);

        // Move the vehicle to the right or left
        //transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horizontalInput);
        // Use Rotate method to turn the vehicle more realistically. Done by pivoting the object's y axis
        transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
    }
}
