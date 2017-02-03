using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUser : NetworkDataObject {

	public int Xp { get; set; }
	public int Position { get; set; }

	public LeaderboardUser()
	{
		
	}
}