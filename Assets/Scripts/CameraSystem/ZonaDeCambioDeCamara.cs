using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDeCambioDeCamara : MonoBehaviour
{
    public KeyCode enterStaticCameraKey;
    public KeyCode exitStaticCameraKey;

    public GameObject StaticCamera;

    bool staticCamera = false;

    private bool inRange = false;

    public CameraManager cm;

    public ControlsMessageText messageText;
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        if (messageText != null) messageText.UpdateText(enterStaticCameraKey, exitStaticCameraKey, staticCamera);
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        if (messageText != null) messageText.ClearText();
    }

    private void Update()
    {
        if (inRange)
        {
            if (!staticCamera && Input.GetKeyDown(enterStaticCameraKey))
            {
                cm.switchToStaticCamera(StaticCamera);
                staticCamera = true; 
                if (messageText != null) messageText.UpdateText(enterStaticCameraKey, exitStaticCameraKey, staticCamera);

            }
            else if(staticCamera && Input.GetKeyDown(exitStaticCameraKey))
            {
                cm.switchToPlayerCamera();
                staticCamera = false;
                if (messageText != null) messageText.UpdateText(enterStaticCameraKey, exitStaticCameraKey, staticCamera);
            }
        }
    }
}
