using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraAccess : MonoBehaviour
{
    public RawImage cameraView;
    WebCamTexture webcamTexture;

    void Start()
    {
        // Check if the device has a camera
        if (WebCamTexture.devices.Length == 0)
            {
            Debug.LogError("No camera detected!");
            return;
        }

        // Set up the camera feed
        webcamTexture = new WebCamTexture();
        cameraView.texture = webcamTexture;
        webcamTexture.Play();
    }

    void Update()
    {
        // Stop the camera feed when the game is paused
        if (Time.timeScale == 0)
        {
            webcamTexture.Pause();
        }
        else
        {
            webcamTexture.Play();
        }
    }
}
