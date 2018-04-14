// PROYECTO NAVARRO ADVANCE PLATFORMER SYSTEM FOR OUYA (NAPSYS)
// LEVELTILES
// AUTOR: JUAN PABLO NAVARRO FENNELL
// FECHA: 02-12-2012
// DESCRIPCIÓN:
// GESTOR DE MAPEO DE TILES EN UN NIVEL CON UN ATLAS HECHO 
// EN CUANDRANTES PREDEFINIDOS

using UnityEngine;
using System.Collections;
 
public class LevelTiles : MonoBehaviour
{
    public int Colum = 0;
	public int Row = 0;
	
	public int textureRes = 16;
	public int extension = 1;
 
    void Start() {
		SetThisTiles(Colum, Row);
    }
	
	public void SetThisTiles(int col, int row) {
		Vector2 offset = new Vector2((float)col / textureRes, (float)row / textureRes); 
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
		
		Vector2 size = new Vector2((1f / textureRes)*extension, (1f / textureRes)*extension);
		GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", size);
	}
}