using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLights : MonoBehaviour
{
    [SerializeField]
    private GameObject[] movingPieces;
    private DragOnClick[] movers;
    private RotateOnDrag[] rotators;

    public Light lightSol;
    public Light[] colorLights;

    void Start()
    {
        lightSol.enabled = true;

        for (int i = 0; i < colorLights.Length; i++)
            colorLights[i].enabled = false;

        for (int i = 0; i < movingPieces.Length; i++)
        {
            rotators[i] = movingPieces[i].GetComponent<RotateOnDrag>();
            movers[i] = movingPieces[i].GetComponent<DragOnClick>();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lightSol.enabled = !lightSol.enabled;

            for (int i = 0; i < colorLights.Length; i++)
                colorLights[i].enabled = !colorLights[i].enabled; 

            if (lightSol.enabled)
            {
                foreach (RotateOnDrag rotator in rotators)
                    rotator.enabled = true;
                foreach (DragOnClick mover in movers)
                    mover.enabled = false;
            }
            else
            {
                foreach (RotateOnDrag rotator in rotators)
                    rotator.enabled = false;
                foreach (DragOnClick mover in movers)
                    mover.enabled = true;
            }
        }
    }
}
