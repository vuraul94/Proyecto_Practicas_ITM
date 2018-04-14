using UnityEngine;
using System.Collections;

public class Objective_Trigger : MonoBehaviour {
	
	public Level_Door door;
	public bool RequiresUseOfItem;
	public Items RequiredItem;
	
	private Player_Inventory inventory;
	
	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		
		if(other.gameObject.tag == "Player") {
			if(RequiresUseOfItem) {
				inventory = other.GetComponent("Player_Inventory") as Player_Inventory;
				if(inventory.getCurrentObject() == RequiredItem) {
						door.unlockdoor();
				}
			}
			else {
				door.unlockdoor();
			}
		}
	}
}
