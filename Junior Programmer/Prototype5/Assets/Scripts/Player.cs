using UnityEngine;

/// <summary>
/// Represents the user and how much lives they possess.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-06-27
/// </para>
/// </remarks>
public class Player
{
    public static int PlayerStartingLives = 3;

    private int _lives;

    /// <summary>
    /// Initializes an instance of a player.
    /// </summary>
    public Player()
    {
        this._lives = PlayerStartingLives;
    }

    /// <summary>
    /// The player's life count.
    /// </summary>
    public int Lives { get { return _lives; } }

    /// <summary>
    /// Decrements the player's life count.
    /// </summary>
    public void LoseLife()
    {
        --_lives;
    }
}
