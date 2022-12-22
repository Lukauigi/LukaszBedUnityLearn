using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behaviour of a falling object in the plachinko game.
/// Author: Lukasz Bednarek
/// Date: 2022-12-21
/// </summary>
public class FallableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rebound") || collision.gameObject.CompareTag("Falling Object"))
        {
            print("Hit Obstacle");
            AudioManager.Instance.PlaySound(Sound.HitObstacle);
        }

        if (collision.gameObject.CompareTag("Success Object"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
            AudioManager.Instance.PlaySound(Sound.Success);
        }
    }
}
