using UnityEngine;
using System.Collections;

public class Game_Over_Screen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.anyKey)
		{
			Application.LoadLevel("Title Screen");
		}
		
		if(transform.position.z >= 12f)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, (float)(transform.position.z - (1 * Time.deltaTime)));
		}
	}
}
