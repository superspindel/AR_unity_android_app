﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Badge object, that is stored on the database and used in the Profile to display active badges for the user.
public class Badge : NetworkDataObject {

	public string UserId { get; set; } // User that the badge belongs to
	public float Completed { get; set; }	// Amount achieved
	public float Maximum { get; set; }		// Maximum amount for badge, used to calculate the value of the badge ( bronze, silver, gold etc)
	public string Title { get; set; } 		// title of badge
	public string Information { get; set;}	// Information about the badge.
	public int SpriteId { get; set; }		// The sprite for the badge, stored in a dictionary in the BadgeDict class
	public DateTime DateFinished { get; set; } // Date achievement was finished

	public Badge()
	{
		
	}
}
