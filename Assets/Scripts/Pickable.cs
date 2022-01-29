using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
   
    // cuando se levante el raton se destruirá el objeto en caso de clickarse
    private void OnMouseUp() {
        // mandar mensaje al inventario

        
        Destroy(this.gameObject);
    }
}
