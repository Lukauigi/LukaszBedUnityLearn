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
    private const float BossSpawnYPosition = 8f;
    
    public static (float, float) RandomRange = (1f, 100f);

    // Enemy spawn chances
    public static float HardEnemySpawnChance = 20f;
    public static int BossSpawnInterval = 5;

    // Powerup spawn chances
    public static float BouncePowerupSpawnChance = 55f;
    public static float MissilePowerupSpawnChance = 25f;
    public static float GroundPoundPowerupSpawnChance = 15f;

    // Spawn cycle durations (in seconds)
    public const float BossWaveSpawnCycleMaxSeconds = 10f;
    public const float EnemySpawnCycleCooldown = 10f;
    public const float PowerupSpawnCycleCooldown = 6f;

    // Attribute(s)
    private float _spawnRange = 9f;
    private int _enemySpawnCount;
    private int _currentEnemyCount;
    private int _waveCount;
    private bool _bossWaveSpawned = false;

    // Ref(s) to other GameObject(s)
    [SerializeField, Tooltip("A list of prefab game objects representing an enemies.")]
    private GameObject[] _enemyPrefabs;
    [SerializeField, Tooltip("A list of prefab game objects representing a powerup.")]
    private GameObject[] _powerupPrefabs;
    [SerializeField, Tooltip("A reference to the enemy boss prefab.")]
    private GameObject _bossEnemyPrefab;

    // other
    private Coroutine _bossWaveSpawnCycle;

    /// <inheritdoc />
    void Start()
    {
        _waveCount = 1;
        _enemySpawnCount = 0;
    }

    /// <inheritdoc />
    private void Update()
    {
        _currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (_currentEnemyCount == 0)
        {
            if (_bossWaveSpawned)
            {
                _bossWaveSpawned = false;
                StopCoroutine(_bossWaveSpawnCycle);
            }
            
            _enemySpawnCount = _waveCount;
            _waveCount++;

            if (_waveCount % BossSpawnInterval == 1)
            {
                SpawnBossWave(_enemySpawnCount);
                _bossWaveSpawned = true;
            }
            else
            {
                SpawnPowerup();
                SpawnEnemyWave(_enemySpawnCount);
            }
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

    private void SpawnBossWave(int enemyCount)
    {
        Instantiate(_bossEnemyPrefab, new Vector3(0f, BossSpawnYPosition, 0f), _bossEnemyPrefab.transform.rotation);
        SpawnEnemyWave(enemyCount);
        _bossWaveSpawnCycle = StartCoroutine(BossWaveSpawnCycle());
    }

    private IEnumerator BossWaveSpawnCycle()
    {
        float cycle = 0;

        yield return new WaitForSeconds(1);
        while (_currentEnemyCount > 0)
        {
            switch (cycle)
            {
                case PowerupSpawnCycleCooldown:
                    SpawnPowerup();
                    break;

                case EnemySpawnCycleCooldown:
                    SpawnEnemyWave(1);
                    break;
            }

            if (cycle != BossWaveSpawnCycleMaxSeconds) ++cycle;
            else cycle = 0;

            yield return new WaitForSeconds(1);
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
