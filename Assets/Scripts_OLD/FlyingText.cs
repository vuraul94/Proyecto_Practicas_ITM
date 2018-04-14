using UnityEngine;
using System.Collections;

public class FlyingText : MonoBehaviour {
private Vector3 posicionInicial;
	private bool displayed;
	
	// Use this for initialization
	void Start () {
		posicionInicial = transform.position;
		displayed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!displayed){
			if (transform.position.z >= -2.5)
			{
				//Debug.Log("BLE!!!!!");
				transform.position = new Vector3(transform.position.x, transform.position.y, (float)(transform.position.z - (1 * Time.deltaTime)));
			}
			else
			{
				displayed = true;
				transform.position = posicionInicial;
			}
		}
	}
}
