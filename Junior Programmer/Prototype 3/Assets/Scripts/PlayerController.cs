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
    // Attributes
    [SerializeField, Tooltip("The force which propels the player into a jump.")]
    private float _jumpForce;
    [SerializeField, Tooltip("The gravity rate of the player.")]
    private float _gravityModifier;
    [SerializeField, Tooltip("Indicator of whether the character is on the ground. For debugging only.")]
    private bool _isGrounded = true;
    [SerializeField, Tooltip("Indicator of the game over state. For debugging only.")]
    private bool _gameOver = false;

    // Sound Effects
    [SerializeField, Tooltip("The character's jump sound effect.")]
    private AudioClip _jumpSound;
    [SerializeField, Tooltip("The character's game over sound effect.")]
    private AudioClip _crashSound;
    public bool GameOver { get { return _gameOver; } }

    // Refs to attatched component(s)
    private Rigidbody _playerRb;
    private Animator _playerAnim;
    private AudioSource _playerAudio;

    // Refs to child object(s)
    [SerializeField, Tooltip("Reference to child explosion particle effect.")]
    private ParticleSystem _explosionParticle;
    [SerializeField, Tooltip("Reference to child running dirt particle effect.")]
    private ParticleSystem _runningDirtParticle;

    ///<inheritdoc />
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= _gravityModifier; // Modifies the rate of the player's gravity.
    }

    ///<inheritdoc />
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !_gameOver)
        {
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); //use impulse ForceMode to simulate an object suddenly receiving a push.
            _isGrounded = false;
            _playerAnim.SetTrigger("Jump_trig");
            _runningDirtParticle.Stop();
            _playerAudio.PlayOneShot(_jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _runningDirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1); //Set to use the first type of death anim
            _explosionParticle.Play();
            _runningDirtParticle.Stop();
            _playerAudio.PlayOneShot(_crashSound);

            _gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
