using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubTaskData {

	public int id;
	public string title;
	public bool isBonus;
	public int xp;

	// info popup
	public string information;
	public string warning; // Merge with information, 

	public List<Tool> tools; // explicit tools for specific task
	public Status status;

	// Use this for initialization
	public SubTaskData () {
		
	}

}
