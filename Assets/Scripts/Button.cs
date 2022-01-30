using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter clickEvent;
    public FMODUnity.StudioEventEmitter hoverEvent;

    public void OnClick()
    {
        clickEvent.SetParameter("Status", 0);
        clickEvent.Play();
    }

    public void OnHover()
    {
        clickEvent.SetParameter("Status", 1);

        clickEvent.Play();
    }
}
