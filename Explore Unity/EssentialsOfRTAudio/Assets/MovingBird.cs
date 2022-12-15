using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Movement { Up, Down } 

public class MovingBird : MonoBehaviour
{
    // various bird chirp audio clips
    public AudioClip birdChirpOne;
    public AudioClip birdChirpTwo;
    public AudioClip birdChirpThree;

    // 2 x coordinates bird will move from
    private float _upperXCoordinate = 10;
    private float _lowerXCoordinate = -10;

    public Vector3 positionChange;

    private Movement _moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        _moveDirection = Movement.Up;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBirdDirection();
        MoveBird();
    }

    private void CheckBirdDirection()
    {
        if (_moveDirection == Movement.Down && transform.position.x <= _lowerXCoordinate) ChangeDirection(Movement.Up);
        else if (_moveDirection == Movement.Up && transform.position.x >= _upperXCoordinate) ChangeDirection(Movement.Down);
        else return;
    }

    private void ChangeDirection(Movement newDirection)
    {
        _moveDirection = newDirection;
    }

    private void MoveBird()
    {
        if (_moveDirection == Movement.Up)
        {
            transform.position += positionChange;
        }
        else if (_moveDirection == Movement.Down)
        {
            transform.position -= positionChange;
        }
    }
}
