// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: AtivateSword
// Description: Triiger tha puts the sword in the character's hand 

using UnityEngine;
using System.Collections;

public class AtivateSword : MonoBehaviour {

	public GameObject sword;
	public SwordWeapon swordWeaponTrigger;

	private Player_Mount _hand;

	public bool available;

	void Start() {
		available = true;
	}

	void OnTriggerEnter(Collider other) {
		if(available && other.gameObject.tag == "Player") {
			_hand = other.gameObject.GetComponent("Player_Mount") as Player_Mount;
			_hand.MountObject(1,sword,swordWeaponTrigger);
			Player_Animations.instance.anim.SetBool("sword",true);
		}
	}
}
