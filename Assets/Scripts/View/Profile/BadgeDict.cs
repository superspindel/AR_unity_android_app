using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
using UnityEditor;


// Dictionary to contain the sprites for the badges
// To be binded to a gameobject that the profileview can get the sprites from when adding the badges to the profile view
[System.Serializable]
public class BadgeDict : MonoBehaviour{

	public Sprite NotFound;	// Sprite set if the id should not get found in the dictionary
	public Sprite Test;
	public Dictionary<int, Sprite> Dict = new Dictionary<int, Sprite>();
	public List<Sprite> Sprites;

	// Returns the sprite requested or the NotFound sprite if there is no key in the dictionary equal to input SpriteId
	public Sprite GetSprite(int spriteId)
	{
		try
		{
			return Dict [spriteId];
		}
		catch(KeyNotFoundException) 
		{
			return NotFound;
		}
	}
	// Fill Dictionary with sprites from folder
	void Awake()
	{
		this.InitializeDictionary ();
		Debug.Log (UnityEngine.Application.dataPath);
		Debug.Log (UnityEngine.Application.persistentDataPath);
		Debug.Log (AssetDatabase.GetAssetPath (NotFound));
		Debug.Log (UnityEngine.Application.persistentDataPath + "/Assets/Icons/Badges/beaker.png");
		Debug.Log (UnityEngine.Application.persistentDataPath+"/Assets/Icons/Badges/beaker.p");
		this.Test = Resources.Load<Sprite> ("beaker");

	}

	private void InitializeDictionary()
	{
		for (int i = 0; i < Sprites.Count; i++) 
		{
			Dict.Add (i, Sprites [i]);
		}
		/*
		string spritePath = "Assets/Icons/Badges/";
		string spriteType = "*.png";
		string[] pdfFiles = Directory.GetFiles(spritePath, spriteType).Select(Path.GetFileName).ToArray();
		for (int i = 0; i < pdfFiles.Length; i++) 
		{
			string totalpath = (spritePath+pdfFiles [i]);
			Dict [i] = totalpath;
		}
		*/
	}



}
