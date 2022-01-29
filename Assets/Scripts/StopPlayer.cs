using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    PlayerMovement player; 

    void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerMovement>();
    }

    void OnTriggerStay(Collider other)
    {

        if (player != null && Input.GetKeyUp(KeyCode.E))
            player.enabled = !player.enabled;

    }
}
