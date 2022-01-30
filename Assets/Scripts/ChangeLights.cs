using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class ChangeLights : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] movingPieces;
    [SerializeField]
    private DragOnClick[] movers;
    [SerializeField]
    private RotateOnDrag[] rotators;
    [SerializeField]
    private GameObject door;
    
    private CorrectPosition[] positionCheckers;

    public Light lightSol;
    public Light[] colorLights;

    void Start()
    {
        positionCheckers = new CorrectPosition[movers.Length]; 

        lightSol.enabled = true;

        for (int i = 0; i < colorLights.Length; i++)
            colorLights[i].enabled = false;

        for (int i = 0; i < movers.Length; i++)
        {
            movers[i].enabled = false;

            //Wenas

            GameObject g = movers[i].gameObject; 

            positionCheckers[i] = g.GetComponent<CorrectPosition>();
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

        int j = 0;
        bool allCorrect = true;
        while (j < positionCheckers.Length && allCorrect)
        {
            allCorrect = positionCheckers[j].correct;

            if (allCorrect)
                Debug.Log("piece(s) in correct position" + j );

        }

        if (allCorrect)
            Debug.Log("All pieces in correct position");
    }

    void openDoor()
    {
        if (door != null)
            door.SetActive(false);
    }
}
