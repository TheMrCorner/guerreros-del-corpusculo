using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    InventoryManager mInventory_;
    UIManager mUIManager_;
    public class LookSensitivityValue : UnityEvent<float>
    {
    }
    private static GameManager instance;
    public static GameManager getInstance() {  return instance;}
    private int stage; //indice del nivel

    //opciones de configuracion
    float LookSensitivity = 1;
    float MasterVolume = 1;
    float FXVolume = 1;
    float MusicVolume = 1;
    bool fullScreen = false;
    Resolution res = new Resolution( 1920, 1080 );
    struct Resolution
    {
        int x, y;
        public Resolution(int X, int Y)
        {
            x = X;y = Y;
        }
    }
    public LookSensitivityValue SensValueEvent;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);

        stage = 0;
        SceneManager.activeSceneChanged += OnSceneChanged;
        SensValueEvent = new LookSensitivityValue();
    }
    
    public void setUI(UIManager ui){
        mUIManager_ = ui;
        mUIManager_.init();
    }

    public void setInventory(InventoryManager inv){
        mInventory_= inv;
    }
    
    public void addObject(string id){
        if(mInventory_!=null){
            mInventory_.addObject(id);
        }
    }
    public void removeObject(string id){
        if(mInventory_!=null){
            mInventory_.removeObject(id);
        }
    }

    public bool hasObject(string s){
        return mInventory_!=null && mInventory_.hasObject(s);
    }
    public string printInventory(){
       return mInventory_.print();
    }

    private void OnSceneChanged(Scene current, Scene next)
    {
        UpdateAllConfigOptions();
    }

    public void UpdateAllConfigOptions()
    {
        setFullScreen(fullScreen);
        SetMasterVolume(MasterVolume);
        SetFXVolume(FXVolume);
        SetMusicVolume(MusicVolume);
        SetLookSensitivity(LookSensitivity);
    }

    public void setFullScreen(bool fullscreen)
    {
        fullScreen = fullscreen;
        Screen.fullScreen = fullscreen;
    }
    public void SetMasterVolume(float volume)
    {
        MasterVolume = volume;
    }

    public void SetFXVolume(float volume)
    {
        FXVolume = volume;
    }
    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
    }

    public void SetLookSensitivity(float sensitivity)
    {
        LookSensitivity = sensitivity;
        SensValueEvent.Invoke(LookSensitivity);
    }
}
