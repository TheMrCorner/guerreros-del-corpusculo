using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMessageText : MonoBehaviour
{
    public void UpdateText(KeyCode enterStaticCameraKey, KeyCode exitStaticCameraKey, bool isStaticCamera)
    {
        if (isStaticCamera)
            this.GetComponent<Text>().text = "Press " + exitStaticCameraKey.ToString() + " to exit";
        else
            this.GetComponent<Text>().text = "Press " + enterStaticCameraKey.ToString() + " to enter";
    }
    public void ClearText()
    {
        this.GetComponent<Text>().text = "";
    }
}
