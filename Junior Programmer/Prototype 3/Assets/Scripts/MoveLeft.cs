using UnityEngine;

/// <summary>
/// Moves an object to the left direction via global orientation.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-04-19
/// </para>
/// </remarks>
public class MoveLeft : MonoBehaviour
{
    [SerializeField, Tooltip("Speed in which this object moves globally left.")]
    private float _speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }
}
