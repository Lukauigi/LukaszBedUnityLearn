using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A button UI element of a difficulty of the gameplay.
/// </summary>
public class DifficultyButton : MonoBehaviour
{
    [SerializeField, 
        Tooltip("A whole number representing the difficulty of the game when this button is selected."),
        Range(1, 3)]
    private int _difficulty;

    private Button _button;
    private GameManager _gameManager;

    /// <summary>
    /// A whole number representing the gameplay difficulty. 
    /// 
    /// <para>
    /// 1 = Easy, 2 = Normal, 3 = Hard.
    /// </para>
    /// </summary>
    public int Difficulty { get { return _difficulty; } }

    /// <inheritdoc />
    void Start()
    {
        _button = GetComponent<Button>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _button.onClick.AddListener(SetDifficulty);
    }

    /// <summary>
    /// Starts the gameplay with the button's set difficulty.
    /// </summary>
    private void SetDifficulty()
    {
        _gameManager.StartGame(_difficulty);
    }
}
