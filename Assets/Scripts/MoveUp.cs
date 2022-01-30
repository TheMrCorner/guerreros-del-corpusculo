using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed=1.0f;
    public float limit=1000;
    void Update()
    {
        if(transform.position.y<limit)
        transform.Translate(new Vector3(0,speed*Time.deltaTime, 0));
        
    }
}
