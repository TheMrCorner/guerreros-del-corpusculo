using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<string> mObjects_;

    private void Start() {
        GameManager.getInstance().setInventory(this);
        mObjects_= new List<string>();
    }

    public void addObject(string id){
        Debug.Log("Cogido objeto " + id);
        mObjects_.Add(id);
        Debug.Log("Cogido objeto 2" + id);
        
    }

    public void removeObject(string id){
        mObjects_.Remove(id);
    }
    public void removeAll(){
        mObjects_.Clear();
    }
    
    public bool hasObject(string id){
        int i=0;
        while(i<mObjects_.Count && mObjects_.ToArray()[i] != id){
            i++;
        }

        return i<mObjects_.Count;
    }
    

}
