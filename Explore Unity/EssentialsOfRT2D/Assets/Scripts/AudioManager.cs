using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Types of sound within the game demo.
/// Author: Lukasz Bednarek
/// Date: 2022-12-21
/// </summary>
public enum Sound { HitObstacle, Success }

/// <summary>
/// Manager of audio emission of the game.
/// Author: Lukasz Bednarek
/// Date: 2022-12-21
/// </summary>
public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    [SerializeField] private AudioClip _success;
    [SerializeField] private AudioClip _hitObstacle;
    private AudioSource _audioOutput;

    // calls when gameobject is made
    private void Awake()
    {
        Instance = this;
        _audioOutput = this.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays the sound called upon.
    /// </summary>
    /// <param name="sound">The sound enumeration to play.</param>
    public void PlaySound(Sound sound)
    {
        if (sound == Sound.HitObstacle) _audioOutput.PlayOneShot(_hitObstacle);
        else if (sound == Sound.Success) _audioOutput.PlayOneShot(_success);
    }
}
