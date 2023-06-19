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
    public TextMeshProUGUI gameOverText;

    // Attribtes
    [SerializeField, Tooltip("A list of targets.")]
    private List<GameObject> _targets;
    private float _spawnRate = 1f;
    private int _score;
    private bool _isGameActive;

    public bool IsGameActive { get { return _isGameActive; } }

    /// <summary>
    /// Updates the score, which is then reflected upon the score UI.
    /// </summary>
    /// <param name="additionalScore">A positive integer number to add to the score.</param>
    public void UpdateScore(int additionalScore)
    {
        _score += additionalScore;
        scoreText.text = "Score: " + _score;
    }

    /// <summary>
    /// Commands a game over state.
    /// </summary>
    public void GameOver()
    {
        _isGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }

    /// <inheritdoc />
    void Start()
    {
        _isGameActive = true;
        StartCoroutine(SpawnTarget());
        _score = 0;
        UpdateScore(0);
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
        while (_isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, _targets.Count);
            Instantiate(_targets[index]);
        }
    }
}
