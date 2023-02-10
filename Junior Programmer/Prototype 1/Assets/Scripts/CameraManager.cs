using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of camera POV changes.
/// 
/// Author: Lukasz Bednarek
/// Date: 2023-02-10
/// </summary>
public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cameras;
    [SerializeField] private bool _isMultiplayer;
    [SerializeField] private bool _isP1;
    [SerializeField] private KeyCode _cameraToggleKey;

    private int _cameraIndex;
    private Rect _P1MultiplayerViewport = new Rect(0, 0, 0.5f, 1);
    private Rect _P2MultiplayerViewport = new Rect(0.5f, 0, 0.5f, 1);

    // Start is called before the first frame update
    void Start()
    {
        if (_isMultiplayer) 
        {
            if (_isP1) _cameras.ForEach(cam => cam.GetComponent<Camera>().rect = _P1MultiplayerViewport);
            else _cameras.ForEach(cam => cam.GetComponent<Camera>().rect = _P2MultiplayerViewport);
        }
        
        
        _cameraIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Change camera on C key press
        if (Input.GetKeyDown(_cameraToggleKey))
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
