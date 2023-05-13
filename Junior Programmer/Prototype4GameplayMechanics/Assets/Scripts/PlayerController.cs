using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Attributes
    [SerializeField, Tooltip("The movement speed of the player.")]
    private float _speed = 5f;
    [SerializeField, Tooltip("The duration of powerups."), Range(0f, 15f)]
    private float _powerupDuration = 7f;
    [SerializeField, Tooltip("The knockback strength of powerups."), Range(0f, 25f)]
    private float _powerupStrength = 15f;
    private bool _hasPowerup = false;
    private Coroutine _powerupActiveCoroutine = null;

    // Ref(s) to attached component(s)
    private Rigidbody _playerRb;

    // Ref(s) to other GameObject(s)
    private GameObject _focalPoint;
    [SerializeField, Tooltip("Reference to visual indication of an active powerup.")]
    private GameObject _powerupIndicator;

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

        _powerupIndicator.transform.position = transform.position + new Vector3(0, -0.55f, 0);
    }

    /// <inheritdoc />
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            if (_hasPowerup)
            {
                StopCoroutine(_powerupActiveCoroutine);
            }

            _hasPowerup = true;
            Destroy(other.gameObject);
            _powerupActiveCoroutine = StartCoroutine(PowerupCountdownRoutine());
            _powerupIndicator.SetActive(true);
        }
    }

    /// <inheritdoc />
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            // Gets direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            
            print("Collided with " + collision.gameObject.name + 
                " with powerup set to " + _hasPowerup);
            enemyRb.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Waits for the powerup to expire.
    /// </summary>
    /// <returns>A second, waiting for the powerup cooldown countdown.</returns>
    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(_powerupDuration);
        _hasPowerup = false;
        _powerupIndicator.SetActive(false);
    }
}
