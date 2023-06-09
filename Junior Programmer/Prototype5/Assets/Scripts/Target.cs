using UnityEngine;

/// <summary>
/// The behaviour of a target game pbject.
/// </summary>
/// 
/// <remarks>
/// Author: Lukasz Bednarek
/// Date: 2023-06-08
/// </remarks>
public class Target : MonoBehaviour
{
    // Attributes
    private float _minSpeed = 12;
    private float _maxSpeed = 16;
    private float _minTorque = -10;
    private float _maxTorque = 10;
    private float _xRange = 4;
    private float _ySpawnPos = -6;

    // Ref(s) to GO components
    private Rigidbody _targetRb;

    /// <inheritdoc />
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();

        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        _targetRb.position = RandomSpawnPos();
    }

    /// <inheritdoc />
    void Update()
    {
        
    }

    /// <summary>
    /// Generates a random movement force.
    /// </summary>
    /// <returns>A Vector3 representing a random movement force.</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    /// <summary>
    /// Generates a random number for an object's rotation torque.
    /// </summary>
    /// <returns>A random torque number.</returns>
    private float RandomTorque()
    {
        return Random.Range(_minTorque, _maxTorque);
    }

    /// <summary>
    /// Generates a random spawn position for the target.
    /// </summary>
    /// <returns>A new Vector3 representing a random 3D coordinate position.</returns>
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }
}
