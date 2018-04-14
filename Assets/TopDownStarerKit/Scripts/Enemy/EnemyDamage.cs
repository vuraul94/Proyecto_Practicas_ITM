// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: EnemyDamage
// Description: On sword collsion, inflicts damage to the enemy through AIEnemy script

using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
	// private reference to AIEmeny class on trigger
	private AIEnemy enemy;
	
	void OnTriggerEnter(Collider other) {
		
		// if collision gameobject is tagged "Enemy"
		if(other.gameObject.tag == "Enemy") {
			
			// Gets the gameobject AIEnemy component reference
			enemy = other.gameObject.GetComponent("AIEnemy") as AIEnemy;
			
			// Inflicts damage
			enemy.Damage();
		}
	}
}
