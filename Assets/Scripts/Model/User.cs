using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : NetworkDataObject
{
	public Sprite profImg { get; set ;} 		// how?
	public int UserIcon { get; set; }
	public string Name { get; set;}
	public int DailyScore { get; set;}
	public int TotalScore { get; set;}
	public int TotalLevel { get; set;}

	public Achievement[] BadgeArray { get; set;}
	public Achievement[] AchArray { get; set;}

	// Badge data
	// store on server? int for example: tasksCompleted, nrOfDaysInTime etc.;
	// Server listens for changes in statistics sends badge id

	// Ach data
	//public List<int> achiId
	//public List<int> badgeId

	public User()
	{
	}
}