using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle forward
        // Gets the transform component of the current object & use the translate method to move the vehicle
        // Vector3.forward is a cleaner way to use transform.Translate(0, 0, 1);
        // Use deltatime to move the vehicle every second instead of frames that could be variable on different users' devices
        transform.Translate(Vector3.forward * Time.deltaTime * _speed); 
    }
}
