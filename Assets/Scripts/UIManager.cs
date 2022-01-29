using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text inventoryList;
    public GameObject inventory;


    public void init(){
        inventoryList.text="";

        desactivateUI();
    }

    void Start()
    {
        GameManager.getInstance().setUI(this);
    }

    public void activateUI(){
        inventory.SetActive(true);
        updateInventoryList();

    }

    public void desactivateUI(){
        inventory.SetActive(false);

    }

    public void updateInventoryList(){
        inventoryList.text= GameManager.getInstance().printInventory();
    }
}
