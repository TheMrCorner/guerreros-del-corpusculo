using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinable : MonoBehaviour
{
    public string requested_object;

    private void Start() {
        
    }

    private void OnMouseDown() {
        if(GameManager.getInstance().hasObject(requested_object)){
            GameManager.getInstance().removeObject(requested_object);
        }
    }
}
