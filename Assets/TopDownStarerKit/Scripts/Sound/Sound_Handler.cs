using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound_Handler : MonoBehaviour {
	
	public static Sound_Handler instance;
	
	public AudioSource speaker1;
	public AudioSource speaker2;
	public AudioSource speaker3;
	
	public AudioClip[] sounds;
	
	public void playsound(int indexOfSound) {
		if(!speaker1.isPlaying) {
			speaker1.PlayOneShot(sounds[indexOfSound]);
		}
		if(!speaker2.isPlaying) {
			speaker2.PlayOneShot(sounds[indexOfSound]);
		}
		if(!speaker3.isPlaying) {
			speaker3.PlayOneShot(sounds[indexOfSound]);
		}
	}
	
	
}