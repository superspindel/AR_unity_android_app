using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUserPref : MonoBehaviour {
	public Text XpText;
	public Text PositionText;
	public Image Border;

	public void Setup(LeaderboardUser ldbUser, bool last)
	{
		this.XpText.text = ldbUser.Xp.ToString ();
		this.PositionText.text = ldbUser.Position.ToString ();

		if (last) 
		{
			Border.enabled = false;
		}
	}
}
