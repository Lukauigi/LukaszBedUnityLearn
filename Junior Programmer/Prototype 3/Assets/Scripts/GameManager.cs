using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Controller of the game world.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-05-02
/// </para>
/// </remarks>
public class GameManager : MonoBehaviour
{
    private float _score;
    [SerializeField]
    [Tooltip("The speed for which the player linearly moves to their starting position in cutscene.")]
    private float _lerpSpeed;

    // Ref(s) to other GameObject components
    private PlayerController _playerController;
    [SerializeField, Tooltip("Spot player stops and end of cutscene to begin gameplay.")]
    private Transform _cutsceneEndPos;

    ///<inheritdoc />
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //_cutsceneEndPos = GameObject.Find("OpeningEndPos").GetComponent<Transform>();
        _score = 0;

        StartCoroutine(OpeningCutscene());
    }

    ///<inheritdoc />
    void Update()
    {
        if (!_playerController.GameOver)
        {
            if (_playerController.IsDashing)
            {
                _score += 10;
            }
            else
            {
                _score++;
            }
        }
        print("Score" + _score);
    }

    /// <summary>
    /// Plays the intro cutscene before gameplay.
    /// </summary>
    /// <returns>The next frame to continue the cutscene.</returns>
    private IEnumerator OpeningCutscene()
    {
        Vector3 startPos = _playerController.transform.position;
        float movementLength = Vector3.Distance(startPos, _cutsceneEndPos.position);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * _lerpSpeed;
        float fractionOfMovement = distanceCovered / movementLength;

        Animator playerAnim = _playerController.GetComponent<Animator>();
        playerAnim.SetFloat("Speed_Multiplier_f", 0.5f);

        while (fractionOfMovement < 1)
        {
            distanceCovered = (Time.time - startTime) * _lerpSpeed;
            fractionOfMovement = distanceCovered / movementLength;
            _playerController.transform.position = Vector3.Lerp(startPos, _cutsceneEndPos.position, 
                fractionOfMovement);
            yield return null;
        }

        playerAnim.SetFloat("Speed_Multiplier_f", 1f);
        _playerController.IsOperable = true;
    }
}
