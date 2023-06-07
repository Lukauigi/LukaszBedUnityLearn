using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Controller of player interactions.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-09
/// </para>
/// </remarks>
public class PlayerController : MonoBehaviour
{
    private static Vector3 PowerupIndicatorOffset = new Vector3(0, -0.55f, 0);

    // Attributes
    [SerializeField, Tooltip("The movement speed of the player.")]
    private float _speed = 5f;
    [SerializeField, Tooltip("The amount of respawns the player has."), Range(1, 9)]
    private int _lives = 1;
    private PowerupScriptableObject _currentPowerup;
    // https://answers.unity.com/questions/1029332/restart-a-coroutine.html
    private Coroutine _powerupActiveCoroutine = null;
    [SerializeField, Tooltip("The Y coordinate which prompts object destruction."),
        Range(-10f, -50f)]
    private float _yPositionThreshold = -10f;

    // Ref(s) to attached component(s)
    private Rigidbody _playerRb;

    // Ref(s) to other GameObject(s)
    private GameObject _focalPoint;
    [SerializeField, Tooltip("Reference to visual indication of an active powerup.")]
    private GameObject _powerupIndicator;

    // Field(s)
    /// <summary>
    /// Returns the current powerup the player has.
    /// </summary>
    public PowerupScriptableObject CurrentPowerup { get { return _currentPowerup; } }
    /// <summary>
    /// Returns the count of player lives.
    /// </summary>
    public int Lives { get { return _lives; } }

    /// <inheritdoc />
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    /// <inheritdoc />
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        // Use the focal point's local forward direction
        _playerRb.AddForce(_speed * forwardInput * _focalPoint.transform.forward);

        _powerupIndicator.transform.position = transform.position + PowerupIndicatorOffset;
    }

    /// <inheritdoc />
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            if (_currentPowerup)
            {
                StopCoroutine(_powerupActiveCoroutine);
                Destroy(GetComponent(Type.GetType(_currentPowerup.Name)));
            }
            
            _currentPowerup = other.GetComponent<Powerup>().PowerupType;
            gameObject.AddComponent(Type.GetType(_currentPowerup.Name));

            Destroy(other.gameObject);
            _powerupActiveCoroutine = StartCoroutine(PowerupCountdownRoutine());
            _powerupIndicator.SetActive(true);
        }
    }

    /// <summary>
    /// Waits for the powerup to expire.
    /// </summary>
    /// <returns>A second, waiting for the powerup cooldown countdown.</returns>
    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(_currentPowerup.Duration);
        Component powerup = GetComponent(Type.GetType(_currentPowerup.Name));

        // Wait for the ground pound action to finish before removing the component
        if (_currentPowerup.Name == "GroundPound")
        {
            while (powerup.GetComponent<GroundPound>().IsGroundPounding)
            {
                print("still pounding ;)");
                yield return null;
            }
        }

        Destroy(powerup);
        _currentPowerup = null;
        _powerupIndicator.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Death()
    {
        DecrementLife();
    }

    /// <summary>
    /// Decrements the life count of the player.
    /// </summary>
    public void DecrementLife()
    {
        if (_lives >= 0)
        {
            --_lives;
        }
    }
}
