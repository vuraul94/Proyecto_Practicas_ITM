using UnityEngine;
using System.Collections;

public class Level_DeadZone : MonoBehaviour {
	Player_Motor motor;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			motor = other.gameObject.GetComponent("Player_Motor") as Player_Motor;
			motor.Deadzone();
			Debug.Log("Dead Zone!");
		}
	}
}
