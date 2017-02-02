using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Dictionary to contain the sprites for the badges
// To be binded to a gameobject that the profileview can get the sprites from when adding the badges to the profile view
[System.Serializable]
public class BadgeDict : MonoBehaviour{

	public Sprite NotFound;	// Sprite set if the id should not get found in the dictionary
	public Dictionary<int, Sprite> Dict;

	// Returns the sprite requested or the NotFound sprite if there is no key in the dictionary equal to input SpriteId
	public Sprite GetSprite(int SpriteId)
	{
		try
		{
			return Dict [SpriteId];
		}
		catch(KeyNotFoundException) 
		{
			return NotFound;
		}
	}

}
