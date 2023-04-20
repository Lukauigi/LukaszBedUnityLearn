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
    [SerializeField]
    private bool _isGrounded = true;
    [SerializeField]
    private bool _gameOver = false;

    public bool GameOver { get { return _gameOver; } }

    // Refs to component(s)
    private Rigidbody playerRb;

    ///<inheritdoc />
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityModifier; // Modifies the rate of the player's gravity.
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); //use impulse ForceMode to simulate an object suddenly receiving a push.
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
