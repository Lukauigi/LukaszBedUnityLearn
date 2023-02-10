using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of camera POV changes.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-04
/// </summary>
public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cameras;
    [SerializeField] private bool _isMultiplayer;
    private int _cameraIndex;
    private Rect _multiplayerViewport = new Rect(0, 0, 0.5f, 1);

    // Start is called before the first frame update
    void Start()
    {
        if (_isMultiplayer) _cameras.ForEach(cam => cam.gameObject.GetComponent<Camera>().rect = _multiplayerViewport);
        
        _cameraIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Change camera on C key press
        if (Input.GetKeyDown(KeyCode.C))
        {
            AssignNewCameraPOV();
        }
    }

    /// <summary>
    /// Enables new camera POV on key press.
    /// </summary>
    private void AssignNewCameraPOV()
    {
        _cameras[_cameraIndex-1].SetActive(false); //disable current camera

        if (_cameraIndex >= _cameras.Count)
        {
            _cameraIndex = 1;
        }
        else
        {
            ++_cameraIndex;
        }

        _cameras[_cameraIndex-1].SetActive(true); //enable new camera
    }
}
