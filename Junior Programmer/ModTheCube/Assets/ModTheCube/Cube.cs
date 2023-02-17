using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of the behaviour of the cube.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-16
/// </summary>
public class Cube : MonoBehaviour
{
    // invoke repeat times
    private readonly float _startDelay = 0;
    private readonly float _invokeInterval = 4f;

    private bool _firstCycle = true;
    private int _locationIndex;

    public Vector3[] locations;

    public MeshRenderer Renderer;
    
    void Start()
    {
        
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        InvokeRepeating(nameof(RandomizeCubeProperties), _startDelay, _invokeInterval);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
    }

    /// <summary>
    /// Randomzies various properties of the cube.
    /// 
    /// Date: 2023-02-16
    /// </summary>
    private void RandomizeCubeProperties()
    {
        if (!_firstCycle) // Is not the first invocation of method
        {
            // Change cube's location from set locations
            _locationIndex = UniqueRandomIndex(_locationIndex, locations.Length);
            
        }
        else
        {
            // Change cube's location from set locations
            _locationIndex = Random.Range(0, locations.Length);

            _firstCycle = false;
        }

        transform.position = locations[_locationIndex];
    }

    /// <summary>
    /// Returns a random index which is not the same as the last index.
    /// 
    /// Date: 2023-02-16
    /// </summary>
    /// <param name="originalIndex">A postitive non-zero integer; the current index.</param>
    /// <param name="size">A positive non-zero integer; size of array.</param>
    /// <returns>A random int not the same as the original index.</returns>
    private int UniqueRandomIndex(int originalIndex, int size)
    {
        int index;
        do
        {
            index = Random.Range(0, size);
        } while (index == originalIndex);

        return index;
    }

}
