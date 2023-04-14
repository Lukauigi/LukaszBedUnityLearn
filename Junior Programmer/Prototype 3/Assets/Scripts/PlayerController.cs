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
    [SerializeField, Tooltip("The force which propels the player into a jump.")]
    private float _jumpForce;
    [SerializeField, Tooltip("The gravity rate of the player.")]
    private float _gravityModifier;

    // Refs to component(s)
    private Rigidbody playerRb;

    ///<inheritdoc />
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityModifier; // Modifies the rate of the player's gravity.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); //use impulse ForceMode to simulate an object suddenly receiving a push.
        }
    }
}
