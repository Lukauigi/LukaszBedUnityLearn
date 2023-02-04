using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of the camera following the player.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-04
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 _offset; // the position offset from the camera to the player
    [SerializeField] private bool _fixedCam;

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

        // Rotates camera's POV if camera is not fixed
        if (!_fixedCam)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * player.GetComponent<PlayerController>().TurnSpeed * player.GetComponent<PlayerController>().HorizontalInput);
            //transform.rotation = player.transform.rotation;
        }
    }

}
