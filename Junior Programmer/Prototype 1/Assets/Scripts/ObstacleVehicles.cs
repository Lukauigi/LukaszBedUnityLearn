using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Obstacle vehicle behaviour. Drives toward the direction of the player.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-04
/// </summary>
public class ObstacleVehicles : MonoBehaviour
{

    [SerializeField] private float _speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }
}
