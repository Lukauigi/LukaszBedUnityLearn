using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    // Added vars
    [SerializeField, Range(0, 5),
        Tooltip("The offset between the top of the background & player control range.")]
    private float _bgYUpperOffset;
    [SerializeField, Range(0, 5),
        Tooltip("The offset between the bottom of the background & player control range.")]
    private float _bgYLowerOffset;
    private float _bgYUpperBound;
    private float _bgYLowerBound;
    private bool _isTooHigh;
    private bool _isTooLow;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>(); //Forgot to assign rigidbody

        float _bgYSize = GameObject.FindGameObjectWithTag("Background").GetComponent<BoxCollider>().size.y;
        _bgYUpperBound = _bgYSize - _bgYUpperOffset;
        _bgYLowerBound = _bgYLowerOffset;
        print(_bgYUpperBound);
        print(_bgYLowerBound);

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        CheckLowerYBound();
        CheckUpperYBound();

        StopFloatForceBeyondUpperBound();

        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !_isTooHigh && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

    private void CheckUpperYBound()
    {
        if (playerRb.transform.position.y >= _bgYUpperBound) _isTooHigh = true;
        else _isTooHigh = false;
    }

    private void CheckLowerYBound()
    {
        if (playerRb.transform.position.y <= _bgYUpperBound) _isTooLow = true;
        else _isTooLow = false;
    }

    /// <summary>
    /// Halts upward float force inflected upon the balloon.
    /// </summary>
    private void StopFloatForceBeyondUpperBound()
    {
        if (_isTooHigh) playerRb.velocity = new Vector3(0, 0);
    }
}
