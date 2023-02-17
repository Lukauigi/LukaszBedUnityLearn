using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    // vars for dog cooldown projectile.
    private bool _canShootDog = true;
    private readonly float _dogCooldown = 0.6f;

    // Update is called once per frame
    void Update()
    {
        print(_canShootDog);

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && _canShootDog)
        {
            StartCoroutine(DogCooldown());
            //ToggleDogCooldown();
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            //Invoke(nameof(ToggleDogCooldown), _dogCooldown);
        }
    }

    /// <summary>
    /// Toggles between false and true if the player can shoot another dog.
    /// 
    /// Date: 2023-02-16
    /// </summary>
    private void ToggleDogCooldown()
    {
        _canShootDog = !_canShootDog;
    }

    /// <summary>
    /// Triggers a cooldown for the player to spawn a dog projectile.
    /// 
    /// Date: 2023-02-16
    /// Credits: Programmer, edited by somdow: https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
    /// </summary>
    /// <returns>Returns a dog projectile cooldown time.</returns>
    private IEnumerator DogCooldown()
    {
        _canShootDog = false;
        yield return new WaitForSeconds(_dogCooldown);
        _canShootDog = true;
    }
}
