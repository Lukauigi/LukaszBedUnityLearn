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
    private PowerupScriptableObject _currentPowerup;
    // https://answers.unity.com/questions/1029332/restart-a-coroutine.html
    private Coroutine _powerupActiveCoroutine = null;

    // Ref(s) to attached component(s)
    private Rigidbody _playerRb;

    // Ref(s) to other GameObject(s)
    private GameObject _focalPoint;
    [SerializeField, Tooltip("Reference to visual indication of an active powerup.")]
    private GameObject _powerupIndicator;

    // Field(s)
    public PowerupScriptableObject CurrentPowerup { get { return _currentPowerup; } }

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
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
        Destroy(GetComponent(Type.GetType(_currentPowerup.Name)));
        _currentPowerup = null;
        _powerupIndicator.SetActive(false);
    }
}
