using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Controller of general game flow.
/// </summary>
/// 
/// <remarks>
/// Author: Lukasz Bednarek
/// Date: 2023-06-08
/// </remarks>
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Attribtes
    [SerializeField, Tooltip("A list of targets.")]
    private List<GameObject> _targets;
    private float _spawnRate = 1f;
    private int _score;

    /// <inheritdoc />
    void Start()
    {
        StartCoroutine(SpawnTarget());
        _score = 0;
        scoreText.text = "Score: " + _score;
    }

    /// <inheritdoc />
    void Update()
    {
        
    }

    /// <summary>
    /// Spawns a random target on the level.
    /// </summary>
    /// <returns>The next second until the spawn rate time is depleted.</returns>
    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, _targets.Count);
            Instantiate(_targets[index]);
        }
    }
}
