using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class UIManager : MonoBehaviour
{
    public class UIStatus : UnityEvent<bool>
    {
    }

    public Text inventoryList;
    public GameObject inventory;
    public UIStatus statusNotif;


    public void init(){
        inventoryList.text="";

        desactivateUI();
    }

    private void Awake()
    {
        statusNotif = new UIStatus();
    }

    void Start()
    {
        GameManager.getInstance().setUI(this);
    }

    public void activateUI(){
        inventory.SetActive(true);
        statusNotif.Invoke(true);
        updateInventoryList();

    }

    public void desactivateUI(){
        inventory.SetActive(false);
        statusNotif.Invoke(false);
    }

    public void updateInventoryList(){
        inventoryList.text= GameManager.getInstance().printInventory();
    }
}
