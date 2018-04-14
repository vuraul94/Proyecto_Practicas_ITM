using UnityEngine;
using System.Collections;
 
public class AutoTransparent : MonoBehaviour
{
    private float materialTransparency = 1f;
    private const float targetTranparency = 0.3f;
    //private float smoothTransparency = 0.1f; // returns to 100% in 0.1 sec
	private Color materialColor;
 
    public void BeTransparent() {
        materialTransparency = targetTranparency;
        
    }
	
	void Start() {
		materialColor = GetComponent<Renderer>().material.color;
	}
	
    void Update() {
        if (materialTransparency < 1.0f) {
			materialColor.a = materialTransparency;
			GetComponent<Renderer>().material.color = materialColor;	
			materialTransparency = Mathf.Lerp(materialTransparency,1f,0.1f);
        }
    }
}