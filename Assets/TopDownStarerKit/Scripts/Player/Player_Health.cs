// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Player_Health
// Description:

using UnityEngine;
using System.Collections;

public class Player_Health : MonoBehaviour {
	public static Player_Health Instance;
	
	public Player_Vitalbar vitabar;
	
	private float health = 100;
	private Player_Motor motor;
	private bool hit;
	
	void Start() {
		Instance = this;
		motor = GetComponent("Player_Motor") as Player_Motor;
	}
	
	void Update() {
		if(health <=0) {
			Player_Input.instance.stopInput();
			Player_Animations.instance.Dead();
			StartCoroutine(Restart());
		}
	}
	
	public float GetHealth() {
		Debug.Log("Salud "+health);
		return health;
	}
	
	public void DamagePlayer(float values) {
		health = health - values;
		motor.DamagePlayer();
	}
	
	public IEnumerator Restart() {
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("LevelLose");
	}
}
