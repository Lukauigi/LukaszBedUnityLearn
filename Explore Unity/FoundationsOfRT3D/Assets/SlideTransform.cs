using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTransform : MonoBehaviour
{
    public float stopDecrementationThreshold;
    public Vector3 positionChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > stopDecrementationThreshold) DecrementPosition();
    }

    private void DecrementPosition()
    {
        transform.localPosition -= positionChange; //decrements GameObject's position.
    }
}
