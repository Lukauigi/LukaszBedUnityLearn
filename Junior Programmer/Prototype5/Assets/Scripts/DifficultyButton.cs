using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class DifficultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    void SetDifficulty()
    {
        print(gameObject.name + " was clicked.");
        _gameManager.StartGame();
    }
}
