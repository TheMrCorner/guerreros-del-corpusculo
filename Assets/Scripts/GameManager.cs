using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    InventoryManager mInventory_;
    UIManager mUIManager_;

   private static GameManager instance;
    public static GameManager getInstance() {  return instance;}
    private int stage; //indice del nivel

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
    }
    
    public void setUI(UIManager ui){
        mUIManager_=ui;
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

    public void ChangeScene(string name){
        SceneManager.LoadScene(name);
    }

    public void QuitApp(){
        Application.Quit();
    }
}
