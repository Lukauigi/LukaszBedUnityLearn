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
    private static int MaxJumps = 2;
    private static int MidairJumpThreshold = 1;
    private static float DefaultAnimSpeed = 1;
    private static float DashAnimSpeed = 2.5f;

    // Attributes
    [SerializeField, Tooltip("The force which propels the player into a jump.")]
    private float _jumpForce;
    [SerializeField, Tooltip("The gravity rate of the player.")]
    private float _gravityModifier;

    private float _midairJumpModifier = 0.85f;
    private int _jumps;


    // Flags
    //[SerializeField, Tooltip("Indicator of whether the character is on the ground. For debugging only.")]
    //private bool _isGrounded = true;
    [SerializeField, Tooltip("Indicator of the game over state. For debugging only.")]
    private bool _gameOver = false;
    private bool _midairJump = false;
    private bool _isDashing = false;

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
        _jumps = MaxJumps;

        Physics.gravity *= _gravityModifier; // Modifies the rate of the player's gravity.
    }

    ///<inheritdoc />
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumps != 0 && !_gameOver)
        {
            //_isGrounded = false;
            --_jumps;
            if (_jumps < MidairJumpThreshold) _midairJump = true;

            float jumpModifier = DetermineJumpForce();
            _playerRb.AddForce(Vector3.up * jumpModifier, ForceMode.Impulse); //use impulse ForceMode to simulate an object suddenly receiving a push.

            
            if (_midairJump) _playerAnim.Play("Running_Jump", 3, 0f);
            else _playerAnim.SetTrigger("Jump_trig");

            _runningDirtParticle.Stop();
            _playerAudio.PlayOneShot(_jumpSound);
        }

        if (Input.GetKey(KeyCode.W) && !_isDashing)
        {
            _isDashing = true;
            _playerAnim.SetFloat("Speed_Multiplier_f", DashAnimSpeed);
            // increase score gain rate
            // access bg and increase speed in move left script
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _isDashing = false;
            _playerAnim.SetFloat("Speed_Multiplier_f", DefaultAnimSpeed);
            // reduce score gain rate
            // access bg and slow down speed in move left script
        }
    }

    ///<inheritdoc />
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //_isGrounded = true;
            _jumps = MaxJumps;
            _midairJump = false;

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

    /// <summary>
    /// Determines the appropriate jump force.
    /// </summary>
    /// <returns>The appropriate jump force.</returns>
    private float DetermineJumpForce()
    {
        if (!_midairJump) return _jumpForce;
        else return _jumpForce * _midairJumpModifier;
    }
}
