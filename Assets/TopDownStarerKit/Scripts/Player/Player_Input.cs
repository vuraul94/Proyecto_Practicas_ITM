// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Player_Input
// Description:

using UnityEngine;
using System.Collections;

public class Player_Input : MonoBehaviour {
	
	public static Player_Input instance;
	private bool read = true;
	
	void Start () {
		instance = this;
	}
	
	void Update () {
		if(read) {

			// Movement
			if(Input.GetAxis("Horizontal") != 0) {
				Player_Motor.instance.MoveHorizontal(Input.GetAxis("Horizontal"));
			}
			
			if(Input.GetAxis("Vertical") != 0) {
				Player_Motor.instance.MoveVertical(Input.GetAxis("Vertical"));
			}
			
			if(Input.GetAxis("LockPos") != 0) {
				Player_Motor.instance.LockPos(true);
			}
			else {
				Player_Motor.instance.LockPos(false);
			}

			// Attack

			if(Input.GetAxis("Fire1") > 0.1) {
				StartCoroutine(stopInputTimed());
				if(Player_Mount.Instance.RightHand != null) {
					Player_Mount.Instance.ActivateWeapon(true);
				}
				Player_Animations.instance.anim.SetBool("is_attaking", true);
				Player_Motor.instance.Attack(1);
			}

			else if(Input.GetAxis("Fire2") > 0.1) {
				StartCoroutine(stopInputTimed());
				if(Player_Mount.Instance.RightHand != null) {
					Player_Mount.Instance.ActivateWeapon(true);
				}
				Player_Animations.instance.anim.SetBool("is_attaking2", true);
				Player_Motor.instance.Attack(2);
			}
		}
	}
	
	public void stopInput() {
		read = false;
	}
	
	public void continueInput() {
		read = true;
	}

	private IEnumerator stopInputTimed() {
		if(read) {
			
			if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
				read = false;
				yield return new WaitForSeconds(0.5f);
			}
			
			else {
				yield return new WaitForSeconds(0.8f);
			}
			
			Player_Mount.Instance.ActivateWeapon(false);
			Player_Animations.instance.anim.SetBool("is_attaking", false);
			Player_Animations.instance.anim.SetBool("is_attaking2", false);
			read = true;
		}
	}

	public void StopTimeSimple(float stopTime) {
		if(read) StartCoroutine(Stoptimer(stopTime));
	}

	private IEnumerator Stoptimer(float stoptime) {
		read = false;
		yield return new WaitForSeconds(1f);
		read = true;
	}
}
