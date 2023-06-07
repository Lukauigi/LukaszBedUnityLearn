using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-06-03
/// </para>
public class DestroyOOB : MonoBehaviour
{
    public static float DefaultYPositionDestroyThreshold = -10f;

    [SerializeField, Tooltip("The Y coordinate which prompts object destruction."),
        Range(-10f, -50f)]
    private float _yPositionThreshold = DefaultYPositionDestroyThreshold;

    /// <inheritdoc />
    void Start()
    {
        
    }

    /// <inheritdoc />
    void Update()
    {
        if (transform.position.y < _yPositionThreshold)
        {
            Destroy(gameObject);
        }
    }
}
