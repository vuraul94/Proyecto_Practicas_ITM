using UnityEngine;
using System.Collections;
 
public class ClearSight : MonoBehaviour {
    public Transform target;
	
	void Update() {
		RaycastHit[] hits;
           
		hits = Physics.RaycastAll(transform.position, transform.forward, Vector3.Distance(this.transform.position,target.position));
		
		foreach(RaycastHit hit in hits) {
			
			Debug.DrawLine(this.transform.position, hit.collider.gameObject.transform.position, Color.magenta);
			
			if(hit.collider.gameObject.tag == "LookTrought") {
				Renderer R = hit.collider.GetComponent<Renderer>();
				AutoTransparent AT = R.GetComponent("AutoTransparent") as AutoTransparent;
	            AT.BeTransparent(); 
			}
        }
    }
}