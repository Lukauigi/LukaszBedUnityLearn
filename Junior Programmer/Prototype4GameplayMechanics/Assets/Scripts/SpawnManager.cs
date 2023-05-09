using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The handler of enemy spawning.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-09
/// </para>
/// </remarks>
public class SpawnManager : MonoBehaviour
{
    [SerializeField, Tooltip("An prefab game object representing an enemy.")]
    private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_enemyPrefab, new Vector3(0, 0, 6), _enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
