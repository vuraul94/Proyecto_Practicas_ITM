// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: AIEnemy
// Description: basic enemy logic for chase in a reachable
// distance according to NavigationMesh baked data

using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour {
	
	//Public
	
	public Transform target; 
	// targets the game character controlled by the player o any other
	// moving element
	
	public Transform basepoint;
	// point of return is the target becomes unreachable
	
	public float speed = 3f;
	// enemy moving speed
	
	public float rotationspeed = 3f;
	// enemy rotation speed to face the target
	
	public Player_Health playerhealth;
	// References the Player_Health class in order to inflict damage
	
	//Private
	
	private Animator anim; // Mecanim Animator reference
	private UnityEngine.AI.NavMeshAgent navMeshAgent; // Navigation Mesh Agent reference
	private bool attack_able = true; 
	private bool damageFlag = true;
	private Rigidbody temp;
	private BoxCollider temp2;
	
	private float health = 10;
	
	void Start() {
		anim = GetComponent("Animator") as Animator;
		navMeshAgent = GetComponent("NavMeshAgent") as UnityEngine.AI.NavMeshAgent;
		navMeshAgent.SetDestination(target.position);
		navMeshAgent.stoppingDistance=1;
	}
	
	
	public void Damage() {
		if(damageFlag) {
			health -= 20f;
			damageFlag = false;
			StartCoroutine(DamageDelay());
		}
	}
	
	void Update () {
		// If enemy health reaches 0
		if (health < 0) {
			
			// stops the navigation mesh
			navMeshAgent.Stop();
			
			// Set the animation state machine parameters
			anim.SetBool("dead",true);
			anim.SetBool("move",false);
			anim.SetBool("attack",false);
			
			// destroys the rigid body
			temp =  this.gameObject.GetComponent("Rigidbody") as Rigidbody;
			Destroy(temp);
			
			// destroy enemy box collider
			temp2 = this.gameObject.GetComponent("BoxCollider") as BoxCollider;
			Destroy(temp2);
		}
		
		// if Player is close enough
		else if(navMeshAgent.stoppingDistance >= Vector3.Distance(target.position, transform.position)) {
			
			// If enemy is even close enough to attack
			if(attack_able){
				// set the animation state machine parameters
				attack_able = false;
				anim.SetBool("move",false);
				anim.SetBool("attack",true);
				
				// Reduce player health
				playerhealth.DamagePlayer(10f);
				
				// Waits 1 sec to atttack again
				StartCoroutine(RestoreAttack());
				
				// Stops the navigation mesh agent to let the animation plays without movement
				navMeshAgent.Stop();
			}
		}
		
			
		// If Enemy move forward to Player's location
		else if(navMeshAgent.stoppingDistance < Vector3.Distance(target.position, transform.position) && 
				Vector3.Distance(target.position, transform.position) <=6) {
				
				// Mesh Navigation Agent moves forward
				navMeshAgent.Resume();
				
				// Set animation state machine parameters
				anim.SetBool("move",true);
				anim.SetBool("attack",false);
				
				// Set the target location
				navMeshAgent.SetDestination(target.position);	
		}
				
			
		// If Player is far away or unreachable
		else if(Vector3.Distance(target.position, transform.position) > 5) {
			
			// Look for tha base point
			if(basepoint != null) {
				
				// The target postions becomes the base point
				navMeshAgent.SetDestination(basepoint.position);
				
				// Move to reach the base point
				if(navMeshAgent.stoppingDistance >= Vector3.Distance(target.position, basepoint.position)) {
					anim.SetBool("move",false);
				}
			}
			
			// Without base point, just stop if player is far away
			else {
				navMeshAgent.Stop();
			}
		}
	}
	
	
	private IEnumerator RestoreAttack() { // wait 1 sec for restoring the attack
		yield return new WaitForSeconds(1);
		attack_able = true;
	}
	
	private IEnumerator DamageDelay() { // wait 1 second for restore the damage value
		yield return new WaitForSeconds(1);
		damageFlag = true;
	}
}
