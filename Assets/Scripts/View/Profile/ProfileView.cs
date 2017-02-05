using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// profile panel script. Runs the profile view and sets up the components within the profile panel.

public class ProfileView : MonoBehaviour {

	public Transform AchievementBox;
	public Transform ProfileInfoBox;
	public Transform BadgeBox;

	private ProfileInfo _infScript;
	private ProfileAchievement _achScript;
	private ProfileBadge _badgeScript;

	private bool _initialized = false;

	// Awake will get the scripts for the transforms that was specified in the Unity control panel
	void Awake() {
		this._achScript = AchievementBox.GetComponent<ProfileAchievement> ();
		this._badgeScript = BadgeBox.GetComponent<ProfileBadge> ();
		this._infScript = ProfileInfoBox.GetComponent<ProfileInfo> ();
	}

	public void LeavePage()
	{
		this._achScript.ReturnChildren ();
		this._badgeScript.ReturnChildren ();
		this.gameObject.SetActive (false);
	}

	public void EnterPage(User profile)
	{
		// TODO: Check Profile.Available
		this.gameObject.SetActive (true);
		if (!this._initialized) 
		{
			profile.Updated += i =>
			{
				this.UpdatePage(profile);
			};
			this._initialized = true;
		}
		this._infScript.SetProfileInfo (profile);
		this._achScript.AddAchievements (profile.Achivements);
		this._badgeScript.AddBadges (profile.Badges);
	}

	public void UpdatePage(User newInfo)
	{
		this.LeavePage ();
		this.EnterPage (newInfo);
	}

}
