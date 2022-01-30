using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeLights : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] movingPieces;
    [SerializeField]
    private DragOnClick[] movers;
    [SerializeField]
    private RotateOnDrag[] rotators;
    
    private CorrectPosition[] positionCheckers;

    public Light lightSol;
    public Light[] colorLights;

    void Start()
    {
        lightSol.enabled = true;

        for (int i = 0; i < colorLights.Length; i++)
            colorLights[i].enabled = false;

        for (int i = 0; i < movers.Length; i++)
        {
            movers[i].enabled = false;
            positionCheckers[i] = movers[i].gameObject.GetComponent<CorrectPosition>();
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
                for (int i = 0; i < movers.Length; i++)
                {
                    rotators[i].enabled = true;
                    movers[i].enabled = false;
                }
            }

            else
            {
                for (int i = 0; i < movers.Length; i++)
                {
                    rotators[i].enabled = false;
                    movers[i].enabled = true; 
                }
            }
        }
        int i;
        bool allCorrect = true;
        while (i < positionCheckers.Length && allCorrect)
        {
            allCorrect = positionCheckers[i].correct;
                if (allCorrect)
            Debug.Log(i + "piece(s) in correct position");
        }

        if (allCorrect)
            Debug.Log("All pieces in correct position");
    }
}
