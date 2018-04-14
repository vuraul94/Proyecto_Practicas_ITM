// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Level_Door
// Description:

using UnityEngine;
using System.Collections;

public class Level_Door : MonoBehaviour {
	
	// Public members
	public Transform door_pivot;
	public bool locked = false;
	public bool RequiresUseOfItem;
	public Items RequiredItem;
	
	// Private members
	private Player_Inventory inventory;
	private Vector3 open = new Vector3(0f,90f,0f);
	private Vector3 close = new Vector3(0f,0f,0f);
	private bool openprocess = false;
	
		
	// Update is called once per frame
	void Update () {
		// scripted opening door
		if(openprocess) {
			if( door_pivot.transform.localEulerAngles != open) {
				door_pivot.transform.localEulerAngles = Vector3.Lerp(door_pivot.transform.localEulerAngles,open,0.2f);
			}
		}
		// scripted closing door
		else {
			if( door_pivot.transform.localEulerAngles != close) {
				door_pivot.transform.localEulerAngles = Vector3.Lerp(door_pivot.transform.localEulerAngles,close,0.2f);
			}
		}
		
		new Vector3(0f,90f,0f);
	}
	
	// Once a door is unlocked, it remains unlocked
	public void unlockdoor() {
		locked=false;
		Level_Data.Instance.SaveData(1f);
	}
	
	// If the payer collides with the door
	void OnTriggerEnter(Collider other) {
		// if is locked, ask for if the player carries the required item to open the door
		if (!locked) {
			if(other.gameObject.tag == "Player") {
				if(RequiresUseOfItem) {
					inventory = other.GetComponent("Player_Inventory") as Player_Inventory;
					if(inventory.getCurrentObject() == RequiredItem) {
						openprocess = true;
						RequiresUseOfItem = false;
						/*if(inventory.getCurrentObject() == Items.DoorKey0) {
							this.transform.position = new Vector3(-100,-100,0);
						}*/
					}
				}
				else {
					openprocess = true;
				}
			}
		}
		
		if(other.gameObject.tag == "Enemy") {
			openprocess = true;
		}
		
	}
	
	// if player if far enough, the door closes
	void OnTriggerExit(Collider other) {
		if (!locked) {
			if(other.gameObject.tag == "Player") {
				openprocess = false;
			}
		}
		
		if(other.gameObject.tag == "Enemy") {
			openprocess = false;
		}
	}
}
