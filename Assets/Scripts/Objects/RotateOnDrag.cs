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
            rotateAxis.Normalize();

            if (gameObject.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)))
                transform.Rotate(0, 0, 1);
            else
                transform.Rotate(0, 0, -1);

            correctPosition.checkPosition();
        }
    }
}
