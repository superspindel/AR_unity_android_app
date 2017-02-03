using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : NetworkDataObject {

	public string Title { get; set; }
	public List<LeaderboardUser> LeaderboardUsers { get; set; }

	public Leaderboard()
	{
		
	}
}