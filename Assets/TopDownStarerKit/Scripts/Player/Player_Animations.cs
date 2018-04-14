// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Player_Animations
// Description:

using UnityEngine;
using System.Collections;

public class Player_Animations : MonoBehaviour {
	
	public static Player_Animations instance;
	public Animator anim;
	private bool dead;
	
	// Use this for initialization
	void Start () {
		instance = this;
		anim = this.gameObject.GetComponent("Animator") as Animator;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Dead() {
		dead = true;
	}
	
	public void MoveAnimation(float speed, float moveh, float movev, bool look_facing, Vector3 reference) {



		if (dead) {
			anim.SetFloat("speed",0f);
			anim.SetFloat("direction",0f);
			anim.SetBool("dead",true);

		}
		else if(!look_facing) {
			anim.SetFloat("speed",speed);
			anim.SetFloat("direction",0f);
		}
		else {
			// Arriba
			if(reference.y > -5 && reference.y < 5) {
				anim.SetFloat("speed",movev);
				anim.SetFloat("direction",moveh);
			}
			// Abajo
			else if(reference.y > 175 && reference.y < 185) {
				anim.SetFloat("speed",movev * -1);
				anim.SetFloat("direction",moveh * -1);
			}

			//Derecha
			else if(reference.y > 85 && reference.y < 95) {
				anim.SetFloat("speed",moveh);
				anim.SetFloat("direction",movev*-1);
			}
			// Izquierda
			else if(reference.y > 265 && reference.y < 275) {
				anim.SetFloat("speed",moveh*-1);
				anim.SetFloat("direction",movev*1);
			}
			
			// Arriba Derecha
			else if(reference.y > 40 && reference.y < 50) {
				anim.SetFloat("speed",movev+moveh);
				anim.SetFloat("direction",moveh+(-1*movev));
			}
			
			// Arriba Izquierda
			else if(reference.y > 310 && reference.y < 320) {
				anim.SetFloat("speed",(-1*moveh)+movev);
				anim.SetFloat("direction",moveh+movev);
			}
			
			// Abajo  Derecha
			else if(reference.y > 130 && reference.y < 140) {
				anim.SetFloat("speed",moveh+(-1*movev));
				anim.SetFloat("direction",-1*(moveh+movev));
			}
			// Abajo  Izaquierda
			else if(reference.y > 220 && reference.y < 230) {
				anim.SetFloat("speed",(-1*moveh)+(-1*movev));
				anim.SetFloat("direction",(-1*moveh)+(movev));
			}	
		}
	}
}
