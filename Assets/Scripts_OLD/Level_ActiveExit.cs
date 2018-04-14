using UnityEngine;
using System.Collections;

public class Level_ActiveExit : MonoBehaviour {

	public Transform target;
	private bool used = false;
	
	void Start() {
		target.position = new Vector3(target.position.x, target.position.y +100, target.position.z);
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			if(!used) {
				target.position = new Vector3(target.position.x, target.position.y -100, target.position.z);
				used = true;
				Debug.Log("Entro");
			}
		}
	}
}