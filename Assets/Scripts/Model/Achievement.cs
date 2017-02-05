using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

// Objects for achievements, stored on the database and retreived to portray the active / completed achievements on the profile.
public class Achievement : NetworkDataObject
{
	public int userID { get; set; } // The user that has completed / is completing the achievement
	public float Completed { get; set;}	// The progress of the achievement
	public float Needed { get; set; }	// The needed amount for the achievement to be completed
	public string Title { get; set; }   // Title of achievement
	public string Information { get; set;}	// Information about the achievement.
	public DateTime DateFinished { get; set; } // Date achievement was finished

	public Achievement()
	{
		
	}
}



