using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// profile panel script. Runs the profile view and sets up the components within the profile panel.

public class ProfileView : MonoBehaviour {

	public Transform AchievementBox;
	public Transform ProfileInfoBox;
	public Transform BadgeBox;

	private User _Profile;

	private ProfileInfo _InfScript;
	private ProfileAchievement _AchScript;
	private ProfileBadge _BadgeScript;

	private bool _Initialized = false;

	// Awake will get the scripts for the transforms that was specified in the Unity control panel
	void Awake() {
		this._AchScript = AchievementBox.GetComponent<ProfileAchievement> ();
		this._BadgeScript = BadgeBox.GetComponent<ProfileBadge> ();
		this._InfScript = ProfileInfoBox.GetComponent<ProfileInfo> ();
	}

	private void _onProfileUpdated(NetworkDataObject i) {
		this.UpdatePage (i as User);
	}
	public void LeavePage()
	{
		if (this._Initialized) {
			this._Profile.Updated -= _onProfileUpdated;
			this._Initialized = false;
		}
		this._AchScript.ReturnChildren ();
		this._BadgeScript.ReturnChildren ();
		this.gameObject.SetActive (false);
	}

	public void EnterPage(User Profile)
	{
		// TODO: Check Profile.Available
		this.gameObject.SetActive (true);
		if (!this._Initialized) 
		{
			Profile.Updated += _onProfileUpdated;
			this._Initialized = true;
		}
		this._InfScript.SetProfileInfo (Profile);
		this._BadgeScript.AddBadges (Profile.Badges);
		this._AchScript.AddAchievements (Profile.Achievements);
		this._Profile = Profile;
	}

	public void UpdatePage(User newInfo)
	{
		this.LeavePage ();
		this.EnterPage (newInfo);
	}

}
