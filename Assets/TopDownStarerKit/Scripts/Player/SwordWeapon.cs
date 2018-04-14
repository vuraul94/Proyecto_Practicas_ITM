using UnityEngine;
using System.Collections;

public class SwordWeapon : MonoBehaviour {

	private bool _active_weapon;
	private AIEnemy enemy;
	void Start() {
		this.GetComponent<Renderer>().material.color = Color.blue;
	}

	public void ActivateSword(bool status) {
		_active_weapon = status;
		if(_active_weapon) {
			this.GetComponent<Renderer>().material.color = Color.red;
		}
		else {
			this.GetComponent<Renderer>().material.color = Color.blue;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(_active_weapon) {
			if(other.gameObject.tag == "Enemy") {
				enemy = other.gameObject.GetComponent("AIEnemy") as AIEnemy;
				enemy.Damage();
			}
		}
	}
}
