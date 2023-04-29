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

    // Refs to attatched component(s)
    private Rigidbody _playerRb;
    private Animator _playerAnim;

    // Refs to child object(s)
    [SerializeField, Tooltip("Reference to child particle effect.")]
    private ParticleSystem _explosionParticle;

    ///<inheritdoc />
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        Physics.gravity *= _gravityModifier; // Modifies the rate of the player's gravity.
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !_gameOver)
        {
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); //use impulse ForceMode to simulate an object suddenly receiving a push.
            _isGrounded = false;
            _playerAnim.SetTrigger("Jump_trig");
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
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1); //Set to use the first type of death anim
            _explosionParticle.Play();
            _gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
