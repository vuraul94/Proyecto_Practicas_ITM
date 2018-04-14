// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: ItemLookAt
// Description: redirects the plane anim to the target 

using UnityEngine;
using System.Collections;

public class ItemLookAt : MonoBehaviour {
	
	public GameObject target;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target.transform.position,Vector3.back);
	}
}
