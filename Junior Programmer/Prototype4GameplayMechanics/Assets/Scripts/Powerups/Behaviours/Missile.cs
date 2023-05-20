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
    public static float YPositionOffset = 0.15f;

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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Input.GetKeyDown(KeyCode.Space) && enemies.Length > 0 && _missileCount != 0)
        {
            Instantiate(_missilePrefab, transform.position + new Vector3(0, YPositionOffset, 0),
                _missilePrefab.transform.rotation);
            _missileCount--;
        }
    }
}
