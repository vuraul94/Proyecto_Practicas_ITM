// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: WinLevel
// Description:

using UnityEngine;
using System.Collections;

public class WinLevel : MonoBehaviour {
	
	// On collision loads the LevelWin scene in the Example Scene folder 
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			Application.LoadLevel("LevelWin");
		}
	}
}
