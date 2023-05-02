using UnityEngine;

/// <summary>
/// Controller of the game world.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-02
/// </para>
/// </remarks>
public class GameManager : MonoBehaviour
{
    private float _score;

    // Ref(s) to other GameObject components
    private PlayerController _playerController;

    ///<inheritdoc />
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _score = 0;
    }

    ///<inheritdoc />
    void Update()
    {
        if (!_playerController.GameOver)
        {
            if (_playerController.IsDashing)
            {
                _score += 10;
            }
            else
            {
                _score++;
            }
        }
        print("Score" + _score);
    }
}
