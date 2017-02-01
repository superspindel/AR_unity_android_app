using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Achievement : NetworkDataObject
{
	public float Completed { get; set;}
	public float Needed { get; set; }
	public string Information { get; set;}

	public Achievement()
	{
		
	}
}



