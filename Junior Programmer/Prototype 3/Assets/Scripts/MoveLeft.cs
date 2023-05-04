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
    public static float MinSpeed = 0;
    public static float DashingWorldSpeedModifier = 2;

    [SerializeField, Tooltip("The default speed in which this object moves globally left.")]
    private float _defaultSpeed = 15f;
    private float _dashScrollSpeed;
    [SerializeField]
    private float _speed;
    private float _destroyBound = -15;

    // Refs to other component(s)
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _speed = _defaultSpeed;
        _dashScrollSpeed = _speed * DashingWorldSpeedModifier;

        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.GameOver == false)
        {
            if (_playerController.IsDashing)
            {
                _speed = _dashScrollSpeed;
            }

            else
            {
                _speed = _defaultSpeed;
            }

            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }

        // Destroy if over the bound & parent gameobject is an obstacle.
        if (transform.position.x < _destroyBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
