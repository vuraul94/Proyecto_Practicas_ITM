using UnityEngine;
using System.Collections;

public class Title_Screen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.anyKey)
			Application.LoadLevel("GGJ_Project");
	}
}
