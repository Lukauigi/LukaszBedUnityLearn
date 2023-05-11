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
    public static int EnemyStartSpawnCount = 3;

    // Attribute(s)
    private float _spawnRange = 9f;
    private int _enemySpawnCount;
    private int _currentEnemyCount;
    private int _waveCount;

    // Ref(s) to other GameObject(s)
    [SerializeField, Tooltip("An prefab game object representing an enemy.")]
    private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _waveCount = 1;
        _enemySpawnCount = 3;
        SpawnEnemyWave(_enemySpawnCount);
    }

    /// <inheritdoc />
    private void Update()
    {
        _currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (_currentEnemyCount == 0)
        {
            _enemySpawnCount = _waveCount;
            SpawnEnemyWave(_waveCount);
            _waveCount++;
        }
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

    /// <summary>
    /// Spawns a wave of enemies.
    /// </summary>
    /// <param name="enemyCount">A positive non-zero integer count of enemies to spawn.</param>
    private void SpawnEnemyWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
        }
    }
}
