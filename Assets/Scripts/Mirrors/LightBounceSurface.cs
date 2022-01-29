using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBounceSurface : MonoBehaviour
{
    public bool lighted;
    private GameObject LightBounced;
    public void LightCol(GameObject lightSource, Vector3 hitPosition, Vector3 reflectedVector)
    {
        lighted = true;
        if (LightBounced == null)
        {
            LightBounced = Instantiate(lightSource);
        }
        LightBounced.transform.position = hitPosition;
        LightBounced.transform.rotation = Quaternion.LookRotation(reflectedVector);
    }

    public void Update()
    {
        lighted = false;
    }

    public void LateUpdate()
    {
        if (lighted == false)
            Destroy(LightBounced);
    }
}
