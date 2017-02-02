using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPrefab : MonoBehaviour {

	public Text AchText;
	public Button ButtonComponent;
	private ProfileAchievement ProfileAch;
	public string Id { get; set;}

	public void Setup(Achievement Achiev, ProfileAchievement ProfAch)
	{
		this.AchText.text = Achiev.Information;
		this.Id = Achiev.Id;
		this.ProfileAch = ProfAch;
	}
}
