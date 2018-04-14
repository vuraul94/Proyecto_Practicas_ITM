// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Level_Data
// Description:

using UnityEngine;
using System.Collections;

public class Level_Data : MonoBehaviour {
	
	public static Level_Data Instance;
	
	public string keyname = "ValorAConsultar";
	

	void Start() {
		Instance = this;
	}
	
	public void SaveData(float values) {
		PlayerPrefs.SetFloat(keyname,values);
	}
	
	public float LoadData() {
		return PlayerPrefs.GetFloat(keyname);
	}
}
