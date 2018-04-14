using UnityEngine;
using System.Collections;

public class Teleport_Relocate : MonoBehaviour {
	public Transform Destination;
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			
		}
		other.gameObject.transform.position = new Vector3(Destination.position.x,Destination.position.y,Destination.position.z);
	}
}
