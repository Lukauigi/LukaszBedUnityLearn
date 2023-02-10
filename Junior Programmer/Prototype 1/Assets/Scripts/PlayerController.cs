using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The bridge between the player & their character.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-10
/// </summary>
public class PlayerController : MonoBehaviour
{
    private (string, string) P1MovementControls = ("Horizontal", "Vertical");
    private (string, string) P2MovementControls = ("Horizontal P2", "Vertical P2");
    private (string, string) _movementControls;

    // Private vars
    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float _turnSpeed = 24.0f;
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _forwardInput;
    [SerializeField] private int _playerID;

    // Public fields
    public float Speed { get { return _speed; } }
    public float TurnSpeed { get { return _turnSpeed; } }
    public float HorizontalInput { get { return _horizontalInput; } }
    public float ForwardInput { get { return _forwardInput; } }
    public int PlayerID { get { return _playerID; } }

    // Start is called before the first frame update
    void Start()
    {
        // checks ID and assigns according player axis movement controls
        if (_playerID == 1)
        {
            _movementControls = P1MovementControls;
        }
        else if (_playerID == 2)
        {
            _movementControls = P2MovementControls;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the input when the player presses the cardinal arrow keys
        // Assigns relative input controls
        _horizontalInput = Input.GetAxis(_movementControls.Item1);
        _forwardInput = Input.GetAxis(_movementControls.Item2);

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
