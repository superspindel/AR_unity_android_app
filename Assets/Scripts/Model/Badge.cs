using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : NetworkDataObject {
	
	public float Completed { get; set; }
	public float Needed { get; set; }
	public int SpriteId { get; set; }

	public Badge()
	{
		
	}
}
