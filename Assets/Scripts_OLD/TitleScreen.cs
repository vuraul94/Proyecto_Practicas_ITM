using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	
	public string next = "TutorialScene";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
			Application.LoadLevel(next);
	}
}
