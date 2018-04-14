// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Player_Rotator
// Description:

using UnityEngine;
using System.Collections;

public class Player_Rotator : MonoBehaviour {
	
	public static Player_Rotator instance;
	public float rotationSpeed = 10f;
	
	private Vector3 dir;
	private bool lock_facing;
	
	void Start () {
		instance = this;
		dir = Vector3.forward + Vector3.up;
		lock_facing = false;
	}
	
	void Update () {
		if(dir != Vector3.zero && !lock_facing) {
			transform.rotation = Quaternion.Slerp(transform.rotation,NormalizeQuaternion(Quaternion.LookRotation(dir)),Time.deltaTime * rotationSpeed);
		}
		
	}

	Quaternion NormalizeQuaternion (Quaternion q) {
		float sum = 0;
		for (int i = 0; i < 4; ++i) {
			sum += q[i] * q[i];
		}
		float magnitudeInverse = 1 / Mathf.Sqrt(sum);

		for (int i = 0; i < 4; ++i) {
			q[i] *= magnitudeInverse;
		}   
		return q;
	}

	public void SetDir(Vector3 newdir, bool lockf) {
		dir = newdir;
		lock_facing = lockf;
	}
}
