using UnityEngine;

/// <summary>
/// Component to control the player.
/// </summary>
/// 
/// <remarks>
/// Author: Lukasz Bednarek
/// Date: 2023-04-14
/// </remarks>
public class PlayerController : MonoBehaviour
{

    // Refs to component(s)
    private Rigidbody playerRb;

    ///<inheritdoc />
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse); //use impulse ForceMode to simulate an object suddenly receiving a push.
        }
    }
}
