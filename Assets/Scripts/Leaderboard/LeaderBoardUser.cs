using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardUser : MonoBehaviour {
	public Text XpText;
	public Text positionText;
	public Image border;

	public void Setup(leaderboardUserObject ldbUsObj, bool last)
	{
		this.XpText.text = ldbUsObj.getXp().ToString();
		this.positionText.text = ldbUsObj.getPosition();

		if (last) 
		{
			border.enabled = false;
		}
	}
}
