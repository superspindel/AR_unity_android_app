using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// profile panel script. Runs the profile view and sets up the components within the profile panel.
public class ProfileView : MonoBehaviour {

	public Transform AchievementBox;
	public Transform ProfileInfoBox;
	public Transform BadgeBox;

	private ProfileInfo _InfScript;
	private ProfileAchievement _AchScript;
	private ProfileBadge _BadgeScript;

	// Start will get the scripts for the transforms that was specified in the Unity control panel
	void Start () {
		this._AchScript = AchievementBox.GetComponent<ProfileAchievement> ();
		this._BadgeScript = BadgeBox.GetComponent<ProfileBadge> ();
		this._InfScript = ProfileInfoBox.GetComponent<ProfileInfo> ();

	}
	// AddAchievement takes a list of achievement objects and runs the script of the achievementbox to insert the achievements in the scene.     
	public void AddAchievement(List<Achievement> AchievementList)
	{
		this._AchScript.AddAchievements (AchievementList);
	}

	// AddBadges takes a list of badge objects and runs the script of the badgebox to insert the badges in the scene.
	public void AddBadges(List<Badge> BadgeList)
	{
		this._BadgeScript.AddBadges (BadgeList);
	}

}
