using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
/// <remarks>
/// Author: Lukasz Bednarek
/// Date: 2023-06-07
/// </remarks>
public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
