using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of the missile powerup.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-18
/// </para>
/// </remarks>
[RequireComponent(typeof(PlayerController))]
public class Missile : MonoBehaviour
{
    private GameObject _missilePrefab;
    private int _missileCount = 3;

    /// <summary>
    /// The number of missiles which can be produced.
    /// </summary>
    public int MissileCount { get { return _missileCount; } }

    /// <inheritdoc />
    private void Awake()
    {
        _missilePrefab = Resources.Load("Prefabs/Missile", typeof(GameObject)) as GameObject;
    }

    /// <inheritdoc />
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _missileCount != 0)
        {
            Instantiate(_missilePrefab, transform.position + _missilePrefab.transform.position, _missilePrefab.transform.rotation);
            _missileCount--;
        }
    }
}
