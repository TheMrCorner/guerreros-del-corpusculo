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
    [SerializeField]
    private GameObject shadowTemplate;
    [SerializeField]
    private GameObject lightTemplate;

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
            if (lightTemplate != null)
                lightTemplate.SetActive(false);
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
                if (lightTemplate != null)
                    lightTemplate.SetActive(false);
                if (shadowTemplate != null)
                    shadowTemplate.SetActive(true);
            }

            else
            {
                for (int i = 0; i < movers.Length; i++)
                {
                    rotators[i].enabled = false;
                    movers[i].enabled = true;
                }
                if (lightTemplate != null)
                    lightTemplate.SetActive(true);
                if (shadowTemplate != null)
                    shadowTemplate.SetActive(false);
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
