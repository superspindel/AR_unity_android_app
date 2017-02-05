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

	public Sprite NotFound{ get; set; }	// Sprite set if the id should not get found in the dictionary
	public Dictionary<int, Sprite> Dict = new Dictionary<int, Sprite>();

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
		this.InitializeDictionary (Resources.LoadAll<Sprite> ("Badges/"));
		this.NotFound = Resources.Load <Sprite>("Badges/trash");
	}

	private void InitializeDictionary(Sprite[] Sprites)
	{
		for (int i = 0; i < Sprites.Length; i++) 
		{
			Dict.Add (i, Sprites [i]);
		}

	}



}
