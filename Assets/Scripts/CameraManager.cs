using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public MonoBehaviour PlayerController;
    public GameObject PlayerCamera; 

    private GameObject staticCameraOnUse;

    private bool staticCamera = false;
    public void switchToStaticCamera(GameObject newCamera)
    {
        PlayerController.enabled = false;

        PlayerCamera.SetActive(false);
        PlayerCamera.GetComponent<AudioListener>().enabled = false;

        staticCameraOnUse = newCamera;
        staticCameraOnUse.SetActive(true);
        staticCameraOnUse.GetComponent<AudioListener>().enabled = true;

        staticCamera = true;
    }

    public void switchToPlayerCamera()
    {
        staticCameraOnUse.SetActive(false);
        staticCameraOnUse.GetComponent<AudioListener>().enabled = false;

        PlayerCamera.SetActive(true);
        PlayerCamera.GetComponent<AudioListener>().enabled = true;

        PlayerController.enabled = true;

        staticCamera = false;
    }

    public bool isStaticCamera()
    {
        return staticCamera;
    }
}
