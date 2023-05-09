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
    // Attribute(s)
    private float _spawnRange = 9;

    // Ref(s) to other GameObject(s)
    [SerializeField, Tooltip("An prefab game object representing an enemy.")]
    private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
    }

    /// <summary>
    /// Generates a random spawn position.
    /// </summary>
    /// <returns>A 3D Vector representing a position.</returns>
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomSpawnPos;
    }
}
