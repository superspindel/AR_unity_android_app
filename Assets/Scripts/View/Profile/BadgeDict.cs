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
public class BadgeDict {

	public static Sprite NotFound{ get; set; }	// Sprite set if the id should not get found in the dictionary
	public static Dictionary<int, Sprite> Dict = new Dictionary<int, Sprite>();
	private static bool _Initialized = false;

	// Returns the sprite requested or the NotFound sprite if there is no key in the dictionary equal to input SpriteId
	public static Sprite GetSprite(int spriteId)
	{
		if (!_Initialized) 
		{
			InitializeDictionary (Resources.LoadAll<Sprite> ("Badges/"));
			BadgeDict.NotFound = Resources.Load <Sprite>("Badges/trash");
			_Initialized = true;
		}
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
		InitializeDictionary (Resources.LoadAll<Sprite> ("Badges/"));
		BadgeDict.NotFound = Resources.Load <Sprite>("Badges/trash");
	}

	private static void InitializeDictionary(Sprite[] Sprites)
	{
		for (int i = 0; i < Sprites.Length; i++) 
		{
			Dict.Add (i, Sprites [i]);
		}

	}



}
