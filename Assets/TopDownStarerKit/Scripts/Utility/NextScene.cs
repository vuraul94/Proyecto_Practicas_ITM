using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {
	
	public bool AutoSwitch = true;
	public string NextSceneName;
	public int WaitSeconds = 3;
	
	// Use this for initialization
	void Start () {
		if (AutoSwitch) {
			StartCoroutine(LoadNextScene());
		}
	}
	
	public IEnumerator LoadNextScene() {
		yield return new WaitForSeconds(WaitSeconds);
		Application.LoadLevel(NextSceneName);
	}
}
