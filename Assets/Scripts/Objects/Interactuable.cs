using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Interactuable : MonoBehaviour
{
    
    [SerializeField] private Material mOutlineMat_;
    [SerializeField] private float outlineScaleFac_;
    [SerializeField] private Color mColor_;
    
    private Renderer rend;
    private bool isCreated=false;
    private void Start() {
        
    }
    Renderer createOutLine(Material outline, float scale, Color color){
        GameObject g= Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer rend= g.GetComponent<Renderer>();
        rend.material=mOutlineMat_;
        rend.material.SetColor("outline color", color);
        rend.material.SetFloat("outline float", scale);
        rend.shadowCastingMode= UnityEngine.Rendering.ShadowCastingMode.Off;

        g.GetComponent<Interactuable>().enabled= false;
        g.GetComponent<Collider>().enabled= false;

        rend.enabled=true;

        return rend;

    }

    private void OnMouseOver() {
        if(!isCreated){
            rend= createOutLine(mOutlineMat_, outlineScaleFac_, mColor_);
            isCreated=true;
        }

    }
    private void OnMouseExit() {
        if(isCreated){
            Destroy(rend.gameObject);
            isCreated=false;
        }
    }

}
