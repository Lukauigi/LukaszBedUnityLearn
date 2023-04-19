using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The handler of spawning obstacles in the scene.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-04-19
/// </para>
/// </remarks>
public class SpawnManager : MonoBehaviour
{
    [SerializeField, Tooltip("Obstacle prefab to spawn periodically.")]
    private GameObject _obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(25, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
