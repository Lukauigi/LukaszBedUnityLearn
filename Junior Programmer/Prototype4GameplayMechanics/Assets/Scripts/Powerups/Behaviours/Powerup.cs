using UnityEngine;

/// <summary>
/// A powerup collectible.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-12
/// </para>
/// </remarks>
public class Powerup : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to powerup.")]
    private PowerupScriptableObject _powerup;

    /// <summary>
    /// The name of the powerup.
    /// </summary>
    public string Name { get { return _powerup.name; } }
    public PowerupScriptableObject PowerupType { get { return _powerup; } }
}
