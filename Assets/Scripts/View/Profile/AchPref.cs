using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPrefab : MonoBehaviour {

	public Text AchText;
	public Button ButtonComponent;
	private ProfileAchievement _profileAch;
	private string UserId { get; set;}

	// Setup of the prefab
	public void Setup(Achievement achiev, ProfileAchievement profAch)
	{
		this.AchText.text = achiev.Information;
		this.UserId = achiev.userID.ToString ();
		this._profileAch = profAch;
	}
}
