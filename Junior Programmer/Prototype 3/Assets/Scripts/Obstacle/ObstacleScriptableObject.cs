using UnityEngine;

/// <summary>
/// Data container of an obstacle.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-04-29
/// </para>
/// </remarks>
[CreateAssetMenu(fileName = "ObstacleScriptableObject", menuName = "ScriptableObjects/Obstacle")]
public class ObstacleScriptableObject : ScriptableObject
{
    public static readonly int MaxStackCount = 3;

    [SerializeField, Range(1, 3),
        Tooltip("The number of this obstacle which can be stacked upon one another")]
    private int _stackCount;

    public int StackCount
    {
        get { return _stackCount; }
    }
}
