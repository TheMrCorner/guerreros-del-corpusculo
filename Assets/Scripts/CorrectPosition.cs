using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPosition : MonoBehaviour
{
    [SerializeField]
    private Transform[] validPositions;

    [SerializeField]
    private float positionLenience = 1f;

    [SerializeField]
    private float rotationLenience = 1f;

    Transform transform;
    public bool correct = false;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    public bool checkPosition()
    {
        foreach (Transform t in validPositions)
        {
            if ((transform.position - t.position).magnitude < positionLenience &&
                Quaternion.Angle(transform.rotation, t.rotation) < rotationLenience)
            {
                return correct = true;
            }
        }
        return correct = false;
    }

        return false;
    }
}
