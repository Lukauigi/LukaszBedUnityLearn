using UnityEngine;

/// <summary>
/// Repeats the background to simulate continuous movement.
/// </summary>
/// 
/// <remarks>
/// <para>
/// Author: Lukasz Bednarek
/// Date: 2023-04-20
/// </para>
/// </remarks>
public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;
    private float _repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2; //need halfway point since that's when the asset repeats itself
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}
