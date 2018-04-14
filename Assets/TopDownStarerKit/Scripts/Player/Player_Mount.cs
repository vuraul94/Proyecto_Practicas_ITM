using UnityEngine;
using System.Collections;

public class Player_Mount : MonoBehaviour {

	public static Player_Mount Instance;

	public GameObject RightHand;
	public GameObject RightShoulder;
	public GameObject LeftHand;
	public GameObject LeftShoulder;

	private SwordWeapon _weapon_right_hand;

	void Start() {
		Instance = this;
	}

	public void ActivateWeapon( bool status) {
		if(_weapon_right_hand != null) _weapon_right_hand.ActivateSword(status);
	}

	public void MountObject(int pos, GameObject mountObject, SwordWeapon swordWeaponTrigger) {
		switch(pos) {
			case 1: 
				mountObject.transform.parent = RightHand.transform;
				mountObject.transform.localPosition = Vector3.zero;
				mountObject.transform.localEulerAngles = Vector3.zero;
				_weapon_right_hand = swordWeaponTrigger;
				

				break;
			case 2: 
				mountObject.transform.parent = LeftHand.transform;
				mountObject.transform.localPosition = Vector3.zero;
				mountObject.transform.localEulerAngles = Vector3.zero;
				break;
			case 3: 
				mountObject.transform.parent = RightShoulder.transform;
				mountObject.transform.localPosition = Vector3.zero;
				mountObject.transform.localEulerAngles = Vector3.zero;
				break;
			case 4: 
				mountObject.transform.parent = LeftShoulder.transform;
				mountObject.transform.localPosition = Vector3.zero;
				mountObject.transform.localEulerAngles = Vector3.zero;
				break;
		}
	}
}
