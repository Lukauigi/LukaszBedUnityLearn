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
    public GameObject[] animalPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spawns a random animal on key press
        if (Input.GetKeyDown(KeyCode.S))
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], new Vector3(0, 0, 20), animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
