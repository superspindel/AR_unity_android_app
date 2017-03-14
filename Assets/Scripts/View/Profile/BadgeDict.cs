using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;


// Dictionary to contain the sprites for the badges
// To be binded to a gameobject that the profileview can get the sprites from when adding the badges to the profile view
[System.Serializable]
public class BadgeDict : MonoBehaviour{

	private int _test = 10;
	private int _dictTest = 0;

	public Sprite NotFound;	// Sprite set if the id should not get found in the dictionary
	public Dictionary<int, string> Dict = new Dictionary<int, string>();

	// Returns the sprite requested or the NotFound sprite if there is no key in the dictionary equal to input SpriteId
	public Sprite GetSprite(int spriteId)
	{
		try
		{
			return (Sprite)AssetDatabase.LoadAssetAtPath(Dict [spriteId], typeof(Sprite));
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

	}

	private void InitializeDictionary()
	{
		string spritePath = "Assets/Icons/Badges/";
		string spriteType = "*.png";
		string[] pdfFiles = Directory.GetFiles(spritePath, spriteType).Select(Path.GetFileName).ToArray();
		for (int i = 0; i < pdfFiles.Length; i++) 
		{
			string totalpath = (spritePath+pdfFiles [i]);
			Dict [i] = totalpath;
		}
	}



}
