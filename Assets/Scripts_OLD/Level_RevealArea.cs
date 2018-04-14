using UnityEngine;
using System.Collections;

public class Level_RevealArea : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			this.transform.position = new Vector3(-100f,-100f,0f);
		}
	}
}
