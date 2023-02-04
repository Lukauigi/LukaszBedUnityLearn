using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // Change Vector3.back to Vector3.forward to move to where the obstacles are
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // Need to multiply by verticalInput since no key press will be zero, which will not rotate the plane
        // verticalInput will also dictate the rotation of the plane's x axis (tilting its nose)
        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
    }
}
