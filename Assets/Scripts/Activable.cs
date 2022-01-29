using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{
    [SerializeField] private Material mOutlineMat_;
    [SerializeField] private float outlineScaleFac_;
    [SerializeField] private Color mColor_;
    
    private Renderer rend;
    private bool isCreated=false;
    
    Renderer createOutLine(Material outline, float scale, Color color){
        GameObject g= Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer rend= g.GetComponent<Renderer>();
        rend.material=mOutlineMat_;
        rend.material.SetColor("outline color", color);
        rend.material.SetFloat("outline float", scale);
        rend.shadowCastingMode= UnityEngine.Rendering.ShadowCastingMode.Off;

        g.GetComponent<Activable>().enabled= false;
        g.GetComponent<Collider>().enabled= false;

        rend.enabled=true;

        return rend;

    }

     private void OnMouseDown() {
        if(!isCreated){
            rend= createOutLine(mOutlineMat_, outlineScaleFac_, mColor_);
            isCreated=true;
        }
        else{
            Destroy(rend.gameObject);
            isCreated=false;
        }

    }
   
}
