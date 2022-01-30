using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public MonoBehaviour PlayerController;
    public GameObject PlayerCamera;
    public MeshRenderer PlayerMesh;

    private GameObject staticCameraOnUse;

    private bool staticCamera = false;
    public bool disablePlayerMeshOnCameraChange = true;

    public void Awake()
    {
        staticCamera = false;
        switchToPlayerCamera();
    }
    public void switchToStaticCamera(GameObject newCamera)
    {
        PlayerController.enabled = false;

        PlayerCamera.SetActive(false);
        PlayerCamera.GetComponent<AudioListener>().enabled = false;

        staticCameraOnUse = newCamera;
        staticCameraOnUse.SetActive(true);
        staticCameraOnUse.GetComponent<AudioListener>().enabled = true;

        staticCamera = true;
        if (disablePlayerMeshOnCameraChange)
        {
            PlayerMesh.enabled = false;
        }
    }

    public void switchToPlayerCamera()
    {
        if (staticCameraOnUse != null)
        {
            staticCameraOnUse.SetActive(false);
            staticCameraOnUse.GetComponent<AudioListener>().enabled = false;
        }

        PlayerCamera.SetActive(true);
        PlayerCamera.GetComponent<AudioListener>().enabled = true;

        PlayerController.enabled = true;

        staticCamera = false;

        if (disablePlayerMeshOnCameraChange)
        {
            PlayerMesh.enabled = true;
        }
    }

    public bool isStaticCamera()
    {
        return staticCamera;
    }
}
