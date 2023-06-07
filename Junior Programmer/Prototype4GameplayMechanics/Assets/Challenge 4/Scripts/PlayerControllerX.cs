using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    [SerializeField, Tooltip("Reference to smoke particle.")]
    private ParticleSystem _smokeParticleBoost;
    [SerializeField, Tooltip("The speed to propell player when initiating turbo boost.")]
    private float _turboBoostSpeed = 1_800f;
    private float _turboBoostCooldown = 4f;
    private bool _canTurboBoost = true;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

        // Turbo boost ability
        if (Input.GetKeyDown(KeyCode.Space) && _canTurboBoost)
        {
            StartCoroutine(TurboBoostCooldown());
            _smokeParticleBoost.transform.position = transform.position;
            _smokeParticleBoost.Play();
            playerRb.AddForce(_turboBoostSpeed * Time.deltaTime * focalPoint.transform.forward, ForceMode.Impulse);
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    /// <summary>
    /// Counts down until turbo boost can be used again.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// Author: Lukasz Bednarek
    /// Date: 2023-05-11
    /// </para>
    /// </remarks>
    /// 
    /// <returns>The next second unitl its zero.</returns>
    private IEnumerator TurboBoostCooldown()
    {
        _canTurboBoost = false;
        yield return new WaitForSeconds(_turboBoostCooldown);
        _canTurboBoost = true;
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position;

            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
