using UnityEngine;

/// <summary>
/// Moves an object to the left direction via global orientation.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-04-19
/// </para>
/// </remarks>
public class MoveLeft : MonoBehaviour
{
    [SerializeField, Tooltip("Speed in which this object moves globally left.")]
    private float _speed = 15;

    private float _destroyBound = -15;

    // Refs to other component(s)
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }

        // Destroy if over the bound & parent gameobject is an obstacle.
        if (transform.position.x < _destroyBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
