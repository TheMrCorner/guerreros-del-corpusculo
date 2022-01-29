using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLights : MonoBehaviour
{

    public Light lightSol;
    public Light[] colorLights;

    void Start()
    {
        lightSol.enabled = true;

        for (int i = 0; i < colorLights.Length; i++)
            colorLights[i].enabled = false; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lightSol.enabled = !lightSol.enabled;

            for (int i = 0; i < colorLights.Length; i++)
                colorLights[i].enabled = !colorLights[i].enabled; 
        }
    }
}
