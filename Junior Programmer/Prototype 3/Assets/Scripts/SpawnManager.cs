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
    [SerializeField, Tooltip("Obstacle prefabs to spawn periodically.")]
    private GameObject[] _obstaclePrefabs;

    private float _startDelay = 2;
    private float _repeatRate = 2;
    private Vector3 _spawnPos = new Vector3(25, 0, 0);

    // Refs to other component(s)
    private PlayerController _playerController;

    // Hacks for boulder to not spawn under ground
    private int _boulderIndex = 3;
    private Vector3 _boulderSpawnPos = new Vector3(25, 1.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
        print(_obstaclePrefabs.Length);
    }

    private void SpawnObstacle()
    {
        if (_playerController.GameOver == false)
        {
            int index = Random.Range(0, _obstaclePrefabs.Length);
            int potentialStackCount = _obstaclePrefabs[index].GetComponent<Obstacle>().GetStackCount();
            int stackCount = Random.Range(1, potentialStackCount+1);

            if (index != _boulderIndex)
            {
                // Get obstacle's y size to properlly stack each obstacle
                float ySize = _obstaclePrefabs[index].GetComponent<BoxCollider>().size.y;

                // Spawn stack of certain number correlating to each case number
                switch (stackCount)
                {
                    case 1:
                        Instantiate(_obstaclePrefabs[index], _spawnPos, _obstaclePrefabs[index].transform.rotation);
                        break;

                    case 2:
                        Instantiate(_obstaclePrefabs[index], _spawnPos, _obstaclePrefabs[index].transform.rotation);
                        Instantiate(_obstaclePrefabs[index], new Vector3(25, ySize, 0), _obstaclePrefabs[index].transform.rotation);
                        break;

                    case 3:
                        Instantiate(_obstaclePrefabs[index], _spawnPos, _obstaclePrefabs[index].transform.rotation);
                        Instantiate(_obstaclePrefabs[index], new Vector3(25, ySize, 0), _obstaclePrefabs[index].transform.rotation);
                        Instantiate(_obstaclePrefabs[index], new Vector3(25, ySize*2, 0), _obstaclePrefabs[index].transform.rotation);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Instantiate(_obstaclePrefabs[index], _boulderSpawnPos, _obstaclePrefabs[index].transform.rotation);
            }
        }
    }
}
