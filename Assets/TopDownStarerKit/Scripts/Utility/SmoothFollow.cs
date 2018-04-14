// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: SmoothFollow
// Description:

using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
	
	// Use this for public variable initialization
	
	public Transform target;    // The target we are following
	public float distance;      // The distance from the target along its Z axis
	public float height;        // the height we want the camera to be above the target
	public float positionDamping;   // how quickly we should get to the target position
	public float rotationDamping;   // how quickly we should get to the target rotation
	
	
	
	void Start () {
		transform.LookAt(target.transform.position);
	}
	
	public void Reset() {
	    distance = 3;
	    height = 1;
	    positionDamping = 6;
	    rotationDamping = 60;
	}
	
	public void LateUpdate () { 
	    ensureReferencesAreIntact();
	   	Vector3 targetPosition = target.position + (Vector3.up * height) + (Vector3.back * distance);
	    transform.position = Vector3.MoveTowards(transform.position, targetPosition, positionDamping * Time.deltaTime);
	}
	
	
	private void ensureReferencesAreIntact() {
	    if (target == null) {
	        Debug.LogError("No target is set in the SmoothFollow Script attached to " + name);
	        this.enabled = false;
	    }
	}
}