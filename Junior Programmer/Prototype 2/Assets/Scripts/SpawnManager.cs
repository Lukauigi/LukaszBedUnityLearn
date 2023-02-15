using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of spawning objects in scene.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-15
/// </summary>
public class SpawnManager : MonoBehaviour
{
    // Private vars for spawning
    private readonly float _spawnRangeXAxis = 20;
    private readonly float _spawnPositionYAxis = 0;
    private readonly float _spawnPositionZAxis = 20;

    // Array of animal prefabs customized in editor
    public GameObject[] animalPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spawns a random animal at a random x position along fixed Y & Z axises on key press
        if (Input.GetKeyDown(KeyCode.S))
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            // randomized x axis position, fixed y and z axis positions
            Vector3 spawnPosition = new Vector3(Random.Range(-_spawnRangeXAxis, _spawnRangeXAxis), _spawnPositionYAxis, _spawnPositionZAxis);

            Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
