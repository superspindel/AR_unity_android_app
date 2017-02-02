using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPrefab : MonoBehaviour {

	public Text AchText;
	public Button ButtonComponent;
	private ProfileAchievement _ProfileAch;
	private string _UserId { get; set;}

	// Setup of the prefab
	public void Setup(Achievement Achiev, ProfileAchievement ProfAch)
	{
		this.AchText.text = Achiev.Information;
		this._UserId = Achiev.userID;
		this._ProfileAch = ProfAch;
	}
}
