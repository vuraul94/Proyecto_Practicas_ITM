using UnityEngine;
using System.Collections;

public class Win_Screen : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		Debug.Log("HOLA");
		if(transform.position.z >= 4.689415f)
		{
			Debug.Log("HOLA2");
			transform.position = new Vector3(transform.position.x, transform.position.y, (float)(transform.position.z - (8 * Time.deltaTime)));
		}else
		{
			Debug.Log("HOLA3");
			StartCoroutine(esperar());
		}
				
	
	}
	
	 	public IEnumerator esperar()
	{
		Debug.Log("HOLA4");
		yield return new WaitForSeconds(1.5f);
		Application.LoadLevel("Title Screen");
	}
	
	
	
}
