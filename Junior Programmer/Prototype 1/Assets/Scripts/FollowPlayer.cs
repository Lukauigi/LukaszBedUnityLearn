using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of the camera following the player.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-03
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 _offset = new Vector3(0, 5, -7); // the position offset from the camera to the player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame after other objects
    void LateUpdate()
    {
        // Follow player position to have the camera follow the player
        // Offset the position by adding to the player's position
        transform.position = player.transform.position + _offset;
    }
}
