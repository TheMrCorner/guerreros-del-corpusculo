using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private CorrectPosition correctPosition;

    void Start()
    {
        correctPosition = getComponent<CorrectPosition>();
    }

    // actualiza el vector auxiliar y el offset 
    private void OnMouseDrag() {
        screenPoint= Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        transform.Rotate(offset, 0.1f);
        correctPosition.checkPosition();
    }
}
