using UnityEngine;
using System.Collections;

public class PlayerAnimatedTile : MonoBehaviour {
    public int columns = 1;
    public int rows = 2;
    public float framesPerSecond = 4f;
	
	
 
    //the current frame to display
    private int index = 0;
 
    void Start() {
		StartCoroutine(updateTiling());
		Vector2 size = new Vector2(1f / columns, 1f / rows);
        GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", size);
    }
 
    private IEnumerator updateTiling()
    {
        
		
		while (true)
        {
            //move to the next index
            index++;
            if (index >= rows * columns)
                index = 0;
 
            //split into x and y indexes
            Vector2 offset = new Vector2((float)index / columns - (index / columns), //x index
                                          (index / columns) / (float)rows);          //y index
 
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
 
            yield return new WaitForSeconds(1f / framesPerSecond);
        }
 
    }
}