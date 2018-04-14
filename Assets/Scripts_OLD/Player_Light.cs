using UnityEngine;
using System.Collections;

public class Player_Light : MonoBehaviour {
	
	public static Player_Light instance;
	public Transform reference;
	public Transform luz;
	private Vector3 posicionDeseada;
	
	void Start () {
		instance = this;
		posicionDeseada = Vector3.zero;
	}
	
	public void setPosition(float hori, float vert)
	{
		
		
		if(hori > 0)
		{
			posicionDeseada = Vector3.right;
		}else{
			if(hori!=0)
			posicionDeseada = Vector3.left;
		}
		if(hori != 0){
			if (vert > 0)
			{
				posicionDeseada += Vector3.forward;
			}else
			{
				if(vert!=0)
				posicionDeseada += Vector3.back;
			}	
		}else
		{
			if (vert > 0)
			{
				posicionDeseada = Vector3.forward;
			}else
			{
				if(vert!=0)
				posicionDeseada = Vector3.back;
			}
		}
		reference.localPosition = posicionDeseada*10;
		luz.LookAt(reference);
	}
}
