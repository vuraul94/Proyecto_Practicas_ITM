using UnityEngine;
using System.Collections;

public class blinkingTxt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Blink());
	}
	
	public IEnumerator Blink()
	{
		while (true)
		{
			GetComponent<GUIText>().enabled = false;
			yield return new WaitForSeconds(.5f);
			GetComponent<GUIText>().enabled = true;
			yield return new WaitForSeconds(.5f);
		}
	}
}
