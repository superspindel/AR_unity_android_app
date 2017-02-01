using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BadgeDict {

	public Sprite NotFound;

	public Dictionary<int, Sprite> Dict;

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
