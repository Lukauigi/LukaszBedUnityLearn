using UnityEngine;

/// <summary>
/// An obstacle in the game world.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-04-29
/// </para>
/// </remarks>
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MoveLeft))]
public class Obstacle : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to according data.")]
    private ObstacleScriptableObject _obstacleData;

    public int GetStackCount() { return _obstacleData.StackCount; }
}
