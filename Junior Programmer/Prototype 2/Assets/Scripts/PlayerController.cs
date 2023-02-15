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
    [SerializeField] float _horizontalInput;
    [SerializeField] float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * _horizontalInput * Time.deltaTime * _speed);
    }
}
