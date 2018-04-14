using UnityEngine;
using System.Collections;

public class Level_Fire : MonoBehaviour {
	
	private Player_Health player;
	public float seconds;
	
	void Start () {
		this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y + 100,this.transform.position.z);
		StartCoroutine(Ubicar());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			player = other.GetComponent("Player_Health") as Player_Health;
			player.DamagePlayer(10);
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "Player") {
			player = other.GetComponent("Player_Health") as Player_Health;
			player.DamagePlayer(10 * Time.deltaTime);
		}
	}
	
	public IEnumerator Ubicar() {
		yield return new WaitForSeconds(seconds);
		this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y - 100,this.transform.position.z);
	}
	
}
