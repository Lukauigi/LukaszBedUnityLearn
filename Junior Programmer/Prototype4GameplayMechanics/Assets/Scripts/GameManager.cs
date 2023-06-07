using UnityEngine;

/// <summary>
/// Handler of broad events and technical aspects of the game.
/// </summary>
/// 
/// <remarks>
/// Author: Lukasz Bednarek
/// Date: 2023-06-07
/// </remarks>
public class GameManager : MonoBehaviour
{
    public const int GameTargetFrameRate = 120;

    /// <summary>
    /// Initiates game over scenario, which pauses the game.
    /// </summary>
    public void GameOver()
    {
        Time.timeScale = 0;
    }

    /// <inheritdoc />
    private void Awake()
    {
        SetFrameRate(GameTargetFrameRate);
    }

    /// <summary>
    /// Sets the frame rate of the game.
    /// </summary>
    private void SetFrameRate(int frameRate)
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }
}
