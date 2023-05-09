using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hanlder of rotating the camera.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-09
/// </para>
/// </remarks>
public class RotateCamera : MonoBehaviour
{
    [SerializeField, Tooltip("The speed in which the camera rotates around the stage.")]
    private float _rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, xInput * _rotationSpeed * Time.deltaTime);
    }
}
