// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Objective_Item
// Description:

using UnityEngine;
using System.Collections;

public class Objective_Item : MonoBehaviour {
	
	
	private Player_Inventory items;
	private Items temporal;
	public Items availbleItem;
	
	public LevelTiles tile;
	
	// Start setting up the tile
	void Start() {
		switch(availbleItem) {
			case Items.NullItem: tile.SetThisTiles(0,(int)Items.NullItem); break;
			case Items.DoorKey1: tile.SetThisTiles(0,(int)Items.DoorKey1); break;
			case Items.DoorKey2: tile.SetThisTiles(0,(int)Items.DoorKey2); break;
			case Items.DoorKey3: tile.SetThisTiles(0,(int)Items.DoorKey3); break;
			case Items.DoorKey4: tile.SetThisTiles(0,(int)Items.DoorKey4); break;
			case Items.DoorKey5: tile.SetThisTiles(0,(int)Items.DoorKey5); break;
			case Items.DoorKey6: tile.SetThisTiles(0,(int)Items.DoorKey6); break;
			case Items.DoorKey7: tile.SetThisTiles(0,(int)Items.DoorKey7); break;
		}
	}
	
	// On trigger switch the alocated item and the one carried by the player
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			items = other.GetComponent("Player_Inventory") as Player_Inventory;
			
			
			temporal = items.getCurrentObject();
			items.setInvetory(availbleItem);
			availbleItem = temporal;
			
			
			
			
			switch(availbleItem) {
				case Items.NullItem: tile.SetThisTiles(0,(int)Items.NullItem); break;
				case Items.DoorKey1: tile.SetThisTiles(0,(int)Items.DoorKey1); break;
				case Items.DoorKey2: tile.SetThisTiles(0,(int)Items.DoorKey2); break;
				case Items.DoorKey3: tile.SetThisTiles(0,(int)Items.DoorKey3); break;
				case Items.DoorKey4: tile.SetThisTiles(0,(int)Items.DoorKey4); break;
				case Items.DoorKey5: tile.SetThisTiles(0,(int)Items.DoorKey5); break;
				case Items.DoorKey6: tile.SetThisTiles(0,(int)Items.DoorKey6); break;
				case Items.DoorKey7: tile.SetThisTiles(0,(int)Items.DoorKey7); break;
			}
		}
	}
}
