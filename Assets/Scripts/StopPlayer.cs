using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    PlayerMovement player;
    MouseLook mouse; 

    void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerMovement>();
    }

    void OnTriggerStay(Collider other)
    {

        if (player != null && Input.GetKeyUp(KeyCode.E))
        {
            player.enabled = !player.enabled;

            if (!player.enabled)
                Cursor.lockState = CursorLockMode.Confined;

            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
