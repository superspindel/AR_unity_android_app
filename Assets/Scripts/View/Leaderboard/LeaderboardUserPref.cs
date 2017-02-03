using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUserPref : MonoBehaviour {
	public Text XpText;
	public Text positionText;
	public Image border;

	public void Setup(LeaderboardUser ldbUser, bool last)
	{
		this.XpText.text = ldbUser.Xp.ToString ();
		this.positionText.text = ldbUser.Position.ToString ();

		if (last) 
		{
			border.enabled = false;
		}
	}
}
