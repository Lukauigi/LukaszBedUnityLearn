using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys object when it is out of its designated bounds.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-16
/// </summary>
public class DestroyOutOfBounds : MonoBehaviour
{
    // Encapsulated vars, bounds to destroy object
    private readonly float _topZAxisBound = 30;
    private readonly float _btmZAxisBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // destroys scripts's parent object when object exceeds the z axis bound too far up or down
        if (transform.position.z > _topZAxisBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < _btmZAxisBound)
        {
            print("Game Over!");
            Destroy(gameObject);
        }
    }
}
