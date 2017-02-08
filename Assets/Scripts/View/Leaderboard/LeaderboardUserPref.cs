using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUserPref : MonoBehaviour {
	private Text XpText;
	private Text PositionText;
	private Image Border;

	public void Setup(LeaderboardUser ldbUser, bool last)
	{
		this.XpText.text = ldbUser.Xp.ToString ();
		this.PositionText.text = ldbUser.Position.ToString ();

		if (last) 
		{
			Border.enabled = false;
		}
	}

	void Awake()
	{
		this.XpText = transform.FindChild ("XP").GetComponent<Text> ();
		this.PositionText = transform.FindChild ("Position").GetComponent<Text> ();
		this.Border = transform.FindChild ("Image").GetComponent<Image> ();
	}
}
