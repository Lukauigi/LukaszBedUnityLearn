using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The direction of which the the bird may move in.
/// Author: Lukasz Bednarek
/// Date: 2022-12-15
/// </summary>
public enum Direction { Up, Down }

/// <summary>
/// Responsible for moving the bird.
/// Author: Lukasz Bednarek
/// Date: 2022-12-15
/// </summary>
public class MovingBird : MonoBehaviour
{
    // 2 x coordinates bird will move from.
    private float _upperXCoordinate = 10;
    private float _lowerXCoordinate = -10;

    // the rate in which the position will change by.
    public Vector3 positionChange;

    // the direction the bird is moving.
    private Direction _moveDirection;

    // Start is called before the first frame update.
    void Start()
    {
        _moveDirection = Direction.Up;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBirdDirection();
        MoveBird();
    }

    /// <summary>
    /// Changes the x-coordinate direction in which the bird moves towards.
    /// </summary>
    private void CheckBirdDirection()
    {
        if (_moveDirection == Direction.Down && transform.position.x <= _lowerXCoordinate) ChangeDirection(Direction.Up);
        else if (_moveDirection == Direction.Up && transform.position.x >= _upperXCoordinate) ChangeDirection(Direction.Down);
        else return;
    }

    /// <summary>
    /// Changes the direction of the bird to the new direction
    /// </summary>
    /// <param name="newDirection"></param>
    private void ChangeDirection(Direction newDirection)
    {
        _moveDirection = newDirection;
    }

    /// <summary>
    /// Moves the bird in a direction.
    /// </summary>
    private void MoveBird()
    {
        if (_moveDirection == Direction.Up)
        {
            transform.position += positionChange;
        }
        else if (_moveDirection == Direction.Down)
        {
            transform.position -= positionChange;
        }
    }
}
