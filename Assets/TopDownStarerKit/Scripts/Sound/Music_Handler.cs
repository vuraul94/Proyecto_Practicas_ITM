// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Music_Handler
// Description: Plays music files with fade in and out between songs

using UnityEngine;
using System.Collections;

public class Music_Handler : MonoBehaviour {
	
	public AudioSource MusicSpeaker;
	
	private bool isFading;
	
	public AudioClip[] Songs;
	
	// Use this for initialization
	void Start () {
		if(Songs.Length > 0) {
			MusicSpeaker.clip = Songs[0];
			MusicSpeaker.loop = true;
			MusicSpeaker.Play();
		} 
	
	}
	
	void Update() {
		if(!MusicSpeaker.isPlaying) {
			MusicSpeaker.Play();
		}
	}
	
	public bool isPlaying() {
		return MusicSpeaker.isPlaying;
	}
	
	public void playMusic(int musicNumber) {
		if(musicNumber < Songs.Length) {
			if(!MusicSpeaker.isPlaying) {
				MusicSpeaker.clip = Songs[musicNumber];
				MusicSpeaker.Play();
			}
			else {
				StartCoroutine(AudioFader(musicNumber));
			}
		}
	}
	
	private IEnumerator AudioFader(int musicNumber) {
		int i;
		if(!isFading) { 
			isFading = true;
			
			for (i = 9; i > 0; i--) {
				MusicSpeaker.volume = i * 0.1f;
				yield return new WaitForSeconds (0.5f);
			}
			
			MusicSpeaker.Stop();
			MusicSpeaker.clip = Songs[musicNumber];
			MusicSpeaker.Play();
			
			for (i = 0; i < 11; i++) {
				MusicSpeaker.volume = i * 0.1f;
				yield return new WaitForSeconds (0.5f);
			}
			
			isFading = false;
		}
	}
}
