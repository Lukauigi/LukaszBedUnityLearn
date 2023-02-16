using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of collisions between objects.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-16
/// </summary>
public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <inheritdoc/>
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
