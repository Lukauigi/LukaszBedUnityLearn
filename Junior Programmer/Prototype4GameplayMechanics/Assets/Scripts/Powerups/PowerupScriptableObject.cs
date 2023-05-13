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

    /// <summary>
    /// The name of the powerup.
    /// </summary>
    public string Name { get { return _name; } }
}
