using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of player input.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-16
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Encapsulated vars changable in editor
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _speed = 20.0f;
    [SerializeField] private float _xAxisRange = 20.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check for movement restriction range left of player
        if (transform.position.x < -_xAxisRange)
        {
            transform.position = new Vector3(-_xAxisRange, transform.position.y, transform.position.z);
        }
        // check for movement restriction range right of player
        if (transform.position.x > _xAxisRange)
        {
            transform.position = new Vector3(_xAxisRange, transform.position.y, transform.position.z);
        }

        // check for key press to fire projectile prefab
        if (Input.GetKeyDown(KeyCode.Space)) //gets input once when key is pressed
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        _horizontalInput = Input.GetAxis("Horizontal");
        // Moves the player when horizontal input is detected (greater or less than 0) and multiplies that to the
        // player's speed value, time from last frame, and multiplies it to a (1, 0, 0) 3D Vector to only change the x coordinates.
        transform.Translate(_horizontalInput * _speed * Time.deltaTime * Vector3.right);
    }
}
