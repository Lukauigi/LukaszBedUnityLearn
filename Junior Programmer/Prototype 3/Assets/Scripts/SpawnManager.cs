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

    private float _startDelay = 2;
    private float _repeatRate = 2;
    private Vector3 _spawnPos = new Vector3(25, 7, 0);

    // Refs to other component(s)
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    private void SpawnObstacle()
    {
        if (_playerController.GameOver == false)
        {
            Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
        }
    }
}
