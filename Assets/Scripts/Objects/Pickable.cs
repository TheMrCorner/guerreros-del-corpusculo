using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public string id;
    // cuando se levante el raton se destruirá el objeto en caso de clickarse
    private void OnMouseUp() {
        
        GameManager.getInstance().addObject(id);
        Destroy(this.gameObject);
    }
}
