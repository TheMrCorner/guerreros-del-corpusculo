using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigMenu : MonoBehaviour
{
    public void SetFullScreen(bool fullscreen)
    {
        GameManager.getInstance().setFullScreen(fullscreen);
    }

    public void SetMasterVolume(float volume)
    {
        GameManager.getInstance().SetMasterVolume(volume);
    }

    public void SetFXVolume(float volume)
    {
        GameManager.getInstance().SetFXVolume(volume);
    }
    public void SetMusicVolume(float volume)
    {
        GameManager.getInstance().SetMusicVolume(volume);
    }

    public void SetLookSensitivity(float sens)
    {
        GameManager.getInstance().SetLookSensitivity(sens);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Camaras");
    }
}
