using UnityEngine;
using System.Collections;

public class Player_Vitalbar : MonoBehaviour {
	
	public void UpdateBar ( float values) {
		this.transform.localScale = new Vector3( values ,this.transform.localScale.y,this.transform.localScale.z);
	}
}
