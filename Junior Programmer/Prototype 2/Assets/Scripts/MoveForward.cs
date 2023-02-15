using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of objects moving forward.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-14
/// </summary>
public class MoveForward : MonoBehaviour
{
    // Encapsulated vars editable in editor
    [SerializeField] private float _speed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}
