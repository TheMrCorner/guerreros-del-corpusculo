using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Sitio donde usar un objeto
public class Combinable : MonoBehaviour
{

    [Header ("Nombre del objeto necesario")]
    public string requested_object;

    private void Start() {
        
    }

    private void OnMouseDown() {
        if(GameManager.getInstance().hasObject(requested_object)){
            GameManager.getInstance().removeObject(requested_object);
        }
    }
}
