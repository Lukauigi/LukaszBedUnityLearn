using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBirdNoises : MonoBehaviour
{
    // various bird chirp audio clips
    public AudioClip birdChirpOne;
    public AudioClip birdChirpTwo;
    public AudioClip birdChirpThree;

    private List<AudioClip> _birdChirpClips;
    private AudioSource _birdChirpAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        _birdChirpClips = new List<AudioClip> { birdChirpOne, birdChirpTwo, birdChirpThree };
        _birdChirpAudioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_birdChirpAudioSource.isPlaying)
        {
            // get a random chirp clip from the list
            int index = Random.Range(0, _birdChirpClips.Count);
            AudioClip birdChirp = _birdChirpClips[index];

            // assign & play clip
            _birdChirpAudioSource.clip = birdChirp;
            _birdChirpAudioSource.Play();
        }
    }
}
