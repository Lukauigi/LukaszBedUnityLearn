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
    public static (float, float) RandomRange = (1f, 100f);

    // Enemy spawn chances
    public static float HardEnemySpawnChance = 20f;

    // Powerup spawn chances
    public static float BouncePowerupSpawnChance = 55f;
    public static float MissilePowerupSpawnChance = 25f;
    public static float GroundPoundPowerupSpawnChance = 15f;

    // Attribute(s)
    private float _spawnRange = 9f;
    private int _enemySpawnCount;
    private int _currentEnemyCount;
    private int _waveCount;

    // Ref(s) to other GameObject(s)
    [SerializeField, Tooltip("A list of prefab game objects representing an enemies.")]
    private GameObject[] _enemyPrefabs;
    [SerializeField, Tooltip("A list of prefab game objects representing a powerup.")]
    private GameObject[] _powerupPrefabs;

    /// <inheritdoc />
    void Start()
    {
        _waveCount = 0;
        _enemySpawnCount = 0;
    }

    /// <inheritdoc />
    private void Update()
    {
        _currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (_currentEnemyCount == 0)
        {
            SpawnPowerup();
            ++_waveCount;
            _enemySpawnCount = _waveCount;
            SpawnEnemyWave(_enemySpawnCount);
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
            float enemyTypeChance = Random.Range(RandomRange.Item1, RandomRange.Item2);
            
            if (enemyTypeChance <= HardEnemySpawnChance)
            {
                Instantiate(_enemyPrefabs[1], GenerateSpawnPosition(), _enemyPrefabs[1].transform.rotation);
            }
            else
            {
                Instantiate(_enemyPrefabs[0], GenerateSpawnPosition(), _enemyPrefabs[0].transform.rotation);
            }
        }
    }

    /// <summary>
    /// Spawns a random powerup on the stage.
    /// </summary>
    private void SpawnPowerup()
    {
        float powerupChance = Random.Range(RandomRange.Item1, RandomRange.Item2);

        if (powerupChance <= BouncePowerupSpawnChance)
        {
            Instantiate(_powerupPrefabs[0], GenerateSpawnPosition(),
                _powerupPrefabs[0].transform.rotation);
        }

        else if (powerupChance > BouncePowerupSpawnChance && 
            powerupChance <= BouncePowerupSpawnChance + MissilePowerupSpawnChance)
        {
            Instantiate(_powerupPrefabs[1], GenerateSpawnPosition(), 
                _powerupPrefabs[1].transform.rotation);
        }

        else
        {
            Instantiate(_powerupPrefabs[2], GenerateSpawnPosition(), 
                _powerupPrefabs[2].transform.rotation);
        }
    }
}
