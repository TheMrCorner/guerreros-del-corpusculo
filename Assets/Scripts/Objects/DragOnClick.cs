using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragOnClick : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private CorrectPosition correctPosition;

    void Start()
    {
        correctPosition = GetComponent<CorrectPosition>();
    }

    // actualiza el vector auxiliar y el offset 
    private void OnMouseDown() {

       screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
       offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    // actualiza la posicion del objetos
   void OnMouseDrag(){

        if (!this.gameObject.GetComponent<RotateOnDrag>().enabled)
        {
            		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
        correctPosition.checkPosition();
        }
	}
}
