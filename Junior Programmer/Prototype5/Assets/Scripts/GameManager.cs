using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    // Game UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public Button _restartButton;
    public GameObject _titleScreen;

    // Attribtes
    [SerializeField, Tooltip("A list of targets.")]
    private List<GameObject> _targets;
    private float _spawnRate = 1f;
    private int _score;
    private bool _isGameActive;

    // Ref(s) to plain c# objects
    private Player _player;

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
    /// Decrements a player life and represents the change on the UI.
    /// </summary>
    public void LoseLife()
    {
        _player.LoseLife();
        UpdateLivesUI();
        if (_player.Lives <= 0)
        {
            GameOver();
        }
        
    }

    /// <summary>
    /// Commands a game over state.
    /// </summary>
    public void GameOver()
    {
        _isGameActive = false;
        _restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Restarts the game by starting the same scene at the beginning.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Initiates the game.
    /// </summary>
    /// <param name="difficulty">A positive integer between 1 to 3 representing the difficulty of 
    /// the gameplay.
    /// </param>
    public void StartGame(int difficulty)
    {
        _titleScreen.gameObject.SetActive(false);
        _isGameActive = true;
        _score = 0;
        _spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLivesUI();
    }

    private void Awake()
    {
        _player = new Player();
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

    /// <summary>
    /// Updates the lives display UI.
    /// </summary>
    private void UpdateLivesUI()
    {
        livesText.text = "Lives: " + _player.Lives;
    }
}
