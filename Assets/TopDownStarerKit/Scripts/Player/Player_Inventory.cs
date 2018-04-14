// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Player_Inventory
// Description:

using UnityEngine;
using System.Collections;

public class Player_Inventory : MonoBehaviour {
	
	public static Player_Inventory Instance;
	
	public LevelTiles tiles;
	
	public Items CurrentObject;
	
	void Start() {
		CurrentObject = Items.NullItem;
		Instance = this;
	}
	
	public Items getCurrentObject() {
		return CurrentObject;
	}
	
	public void setInvetory(Items newObject) {
		CurrentObject = newObject;
	}
	
	public void dropInvetory() {
		CurrentObject = Items.NullItem;
	}
	

	
	
}
