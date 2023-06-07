using UnityEngine;

/// <summary>
/// An enumeration of a powerup.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-12
/// </para>
/// </remarks>
[CreateAssetMenu(fileName = "PowerupScriptableObject", menuName = "ScriptableObjects/Powerups")]
public class PowerupScriptableObject : ScriptableObject
{
    [SerializeField, Tooltip("Powerup name.")]
    private string _name;
    [SerializeField, Tooltip("How long the powerup lasts.")]
    private float _duration;
    [SerializeField, Tooltip("The strength to push away enemies.")]
    private float _knockback;

    /// <summary>
    /// The name of the powerup.
    /// </summary>
    public string Name { get { return _name; } }
    /// <summary>
    /// How long the powerup lasts.
    /// </summary>
    public float Duration { get { return _duration; } }
    /// <summary>
    /// The strength to push away enemies.
    /// </summary>
    public float Knockback { get { return _knockback; } }
}
