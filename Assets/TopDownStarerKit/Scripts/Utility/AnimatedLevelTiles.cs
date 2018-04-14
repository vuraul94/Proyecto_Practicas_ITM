// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: AnimatedLevelTiles
// Description: Plays a sprite animation by offsetting and resizing the texture 

using UnityEngine;
using System.Collections;
 
class AnimatedLevelTiles : MonoBehaviour
{
    // Sprite settings
	public int columns = 2;
    public int rows = 2;
    public float framesPerSecond = 10f;
	
	
 
    //the current frame to display
    private int index = 0;
 
    void Start() {
		// starts the animation
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
 
            // set the new offset
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
 
            // waits for next frame
			yield return new WaitForSeconds(1f / framesPerSecond);
        }
 
    }
}