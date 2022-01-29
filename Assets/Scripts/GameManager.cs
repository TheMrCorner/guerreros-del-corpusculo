using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InventoryManager mInventory_;
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
}
