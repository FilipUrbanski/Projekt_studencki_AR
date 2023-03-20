using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ZXing;

public class CameraAccess : MonoBehaviour
{
    public RawImage cameraView;
    WebCamTexture webcamTexture;
    BarcodeReader barcodeReader;

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

        // Initialize a new BarcodeReader instance
        barcodeReader = new BarcodeReader();
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

            // Detect and decode QR codes
            Result result = barcodeReader.Decode(webcamTexture.GetPixels32(), webcamTexture.width, webcamTexture.height);

            if (result != null)
            {
                // Handle the QR code result here
                Debug.Log("QR code detected: " + result.Text);
            }
        }
    }
}
