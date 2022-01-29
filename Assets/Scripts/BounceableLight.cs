using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BounceableLight : MonoBehaviour
{
    public float maxDistance;
    public GameObject SpotLightPrefab;
    public Transform directionHelper;

    private void Update()
    {
        CastRay(transform.position, directionHelper.position - transform.position);
    }

    void CastRay(Vector3 pos, Vector3 dir)
    {
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        Debug.DrawLine(pos, pos + dir * maxDistance);
        if (Physics.Raycast(ray, out hit, maxDistance, LayerMask.GetMask("Mirror")) && hit.collider.tag == "Mirror")
        {
            hit.collider.gameObject.GetComponent<LightBounceSurface>().LightCol(SpotLightPrefab, hit.point, Vector3.Reflect(ray.direction, hit.normal));
            CastRay(hit.point, Vector3.Reflect(ray.direction, hit.normal));
        }
    }
}
