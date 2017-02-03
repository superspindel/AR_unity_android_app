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

	// Awake will get the scripts for the transforms that was specified in the Unity control panel
	void Awake() {
		this._AchScript = AchievementBox.GetComponent<ProfileAchievement> ();
		this._BadgeScript = BadgeBox.GetComponent<ProfileBadge> ();
		this._InfScript = ProfileInfoBox.GetComponent<ProfileInfo> ();
	}

	public void LeavePage()
	{
		this._AchScript.ReturnChildren ();
		this._BadgeScript.ReturnChildren ();
	}

	public void EnterPage(User Profile, List<Achievement> AchievementList, List<Badge> BadgeList)
	{
		this._InfScript.SetProfileInfo (Profile);
		this._AchScript.AddAchievements (AchievementList);
		this._BadgeScript.AddBadges (BadgeList);
	}

	public void UpdatePage(User newInfo)
	{
		this.LeavePage ();
		this.EnterPage (newInfo);
	}

}
