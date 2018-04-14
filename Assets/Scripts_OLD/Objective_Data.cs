using UnityEngine;
using System.Collections;

public class Objective_Data : MonoBehaviour {
	
	public static Objective_Data Instance;
	
	public string keyname = "ItemSpotAConsultar";
	
	void Start() {
		Instance = this;
	}
	
	public void SaveData(Items SaveItem) {
		switch(SaveItem) {
			case Items.NullItem: break;
			case Items.DoorKey1: break;
			case Items.DoorKey2: break;
		}
		//PlayerPrefs.SetFloat(keyname, float.Parse(SaveItem));
	}
	
//	public Items LoadData() {
//		return PlayerPrefs.GetFloat(keyname);
//	}
}
