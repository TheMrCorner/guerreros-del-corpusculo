using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 rotateAxis;
    private CorrectPosition correctPosition;

    void Start()
    {
        correctPosition = GetComponent<CorrectPosition>();
    }

    // actualiza el vector auxiliar y el offset 
    private void OnMouseDrag() {

        if (!this.gameObject.GetComponent<DragOnClick>().enabled) {
            screenPoint= Camera.main.WorldToScreenPoint(gameObject.transform.position);
            rotateAxis = gameObject.transform.position - Camera.main.transform.position;

            if (gameObject.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)));
                transform.rotation = Quaternion.Euler(rotateAxis.Normalize()) * Vector3.forward;
            else
                transform.rotation = Quaternion.Euler(rotateAxis.Normalize()) * Vector3.back;
                //transform.Rotate(rotateAxis, -1f);

            correctPosition.checkPosition();
        }
    }
}
