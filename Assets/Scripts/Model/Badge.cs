using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Badge object, that is stored on the database and used in the Profile to display active badges for the user.
public class Badge : NetworkDataObject {

	public int userID { get; set; } // User that the badge belongs to
	public float Completed { get; set; }	// Amount achieved
	public float Maximum { get; set; }		// Maximum amount for badge, used to calculate the value of the badge ( bronze, silver, gold etc)
	public int SpriteId { get; set; }		// The sprite for the badge, stored in a dictionary in the BadgeDict class

	public Badge()
	{
		
	}
}
