using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of player input.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-14
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Encapsulated vars changable in editor
    [SerializeField] float _horizontalInput;
    [SerializeField] float _speed = 10.0f;
    [SerializeField] float _xAxisRange = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -_xAxisRange)
        {
            transform.position = new Vector3(-_xAxisRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > _xAxisRange)
        {
            transform.position = new Vector3(_xAxisRange, transform.position.y, transform.position.z);
        }

        _horizontalInput = Input.GetAxis("Horizontal");
        // Moves the player when horizontal input is detected (greater or less than 0) and multiplies that to the
        // player's speed value, time from last frame, and multiplies it to a (1, 0, 0) 3D Vector to only change the x coordinates.
        transform.Translate(_horizontalInput * _speed * Time.deltaTime * Vector3.right);
    }
}
