using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys object when it is out of its designated bounds.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-14
/// </summary>
public class DestroyOutOfBounds : MonoBehaviour
{
    // Encapsulated vars
    private float _zAxisBound = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // destroys scripts's parent object when object exceeds the z axis bound too far up or down
        if (transform.position.z > _zAxisBound || transform.position.z < -_zAxisBound)
        {
            Destroy(gameObject);
        }
    }
}
