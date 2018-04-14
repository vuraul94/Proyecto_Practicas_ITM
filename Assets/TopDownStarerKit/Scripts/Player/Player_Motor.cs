// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Player_Motor
// Description:

using UnityEngine;
using System.Collections;

public class Player_Motor : MonoBehaviour {
	public float FactorGravedad = 20f;
	public float FactorVelocidad = 5f;
	public float FactorLock = 0.6f;
	
	private Vector3 desplazamientoHor;
	private Vector3 desplazamientoVer;
	private Vector3 gravedad;
	private CharacterController charactercontroller;
	private bool previousContactState;
	
	public static Player_Motor instance;
	
	private Vector3 facing_hor;
	private Vector3 storedRotation;
	private Vector3 facing_ver;
	private bool lock_facing;
	private bool getHit;
	public float hitforce;
	public Transform LevelStartPoint;

	
	
	void Start () 
	{
		instance = this;
	
		charactercontroller = GetComponent("CharacterController") as CharacterController;
		facing_hor          = Vector3.zero;
		facing_ver          = Vector3.zero;
		lock_facing         = false;
		storedRotation      = Vector3.zero;
		getHit = false;
	}
	
	void Update () {
		ApplyGravity();


		if(previousContactState == false && previousContactState != isGroundTouch()) {
			Player_Input.instance.StopTimeSimple(3f);
		}

		previousContactState = isGroundTouch();



		if(isGroundTouch()){
			Player_Animations.instance.anim.SetBool("is_grounded",isGroundTouch());
		}
		else {
			Player_Animations.instance.anim.SetBool("is_grounded",isGroundTouch());
		}






		if (getHit && hitforce < 5) {
			hitforce = hitforce + Time.deltaTime * 10;
		}
		else {
			hitforce = 0f;
			getHit = false;
		}
		
		Vector3 desplazamiento = desplazamientoHor + desplazamientoVer + gravedad + ((Vector3.up+(-5*facing_ver)) * hitforce);
		
		if(!lock_facing) storedRotation = transform.localEulerAngles;

		
		if((desplazamientoHor + desplazamientoVer) == Vector3.zero) {
			Player_Animations.instance.MoveAnimation(0f, 0f, 0f, lock_facing,storedRotation);
		}
		else {
			Player_Animations.instance.MoveAnimation(1f, desplazamientoHor.x, desplazamientoVer.z, lock_facing,storedRotation);
		}
		
		if(desplazamientoHor != Vector3.zero ) {
			if(desplazamientoHor.x > 0) {
				facing_hor = Vector3.right;
			}
			else {
				facing_hor = Vector3.left;
			}
		}
		else facing_hor = Vector3.zero;
		
		
		if(desplazamientoVer != Vector3.zero ) {
			if(desplazamientoVer.z > 0) {
				facing_ver = Vector3.forward;
			}
			else {
				facing_ver = Vector3.back;
			}
		}
		else facing_ver = Vector3.zero;
		
		if(lock_facing) {
			FactorLock = 0.6f; 
		}
		else {
			FactorLock = 1f; 
		}
		
		Player_Rotator.instance.SetDir(facing_hor + facing_ver,lock_facing);
			
		charactercontroller.Move(desplazamiento * Time.deltaTime*FactorLock);
		desplazamientoHor = desplazamientoVer = Vector3.zero;
	}
	
	public void MoveHorizontal(float dir)
	{
		desplazamientoHor = Vector3.right * dir * FactorVelocidad;
	}
	
	public void MoveVertical(float dir)
	{
		desplazamientoVer = Vector3.forward * dir * FactorVelocidad;	
	}
	
	void ApplyGravity()
	{
		if(charactercontroller.isGrounded) {
			gravedad = Vector3.zero;
		}
		else {
			gravedad = Vector3.down * FactorGravedad;
		}
	}
	
	public void DamagePlayer() {
		getHit = true;
	}
	
	public void LockPos(bool lockpos) {
		lock_facing = lockpos;
	}

	public void Attack(int typeOfAttack) {
		switch(typeOfAttack){
		case 1: 
			// Motor Attack Related
			break;
		}
	}

	private bool isGroundTouch() {
		if (Physics.Raycast((transform.position+(Vector3.up*0.5f)), Vector3.down, 0.6f)) {
			return true;
		}
		else {
			return false;
		}
	}

	public void Deadzone() {
		this.transform.position = LevelStartPoint.position;
	}
}

