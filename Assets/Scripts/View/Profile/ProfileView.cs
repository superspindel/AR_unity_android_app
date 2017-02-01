using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView : MonoBehaviour {

	public Transform AchievementBox;
	public Transform ProfileInfoBox;
	public Transform BadgeBox;

	private ProfileAchievement AchScript;
	private ProfileBadge BadgeScript;

	public List<Achievement> AchievementList;
	public List<Badge> BadgeList;

	// Use this for initialization
	void Start () {
		this.AchScript = AchievementBox.GetComponent<ProfileAchievement> ();
		this.BadgeScript = BadgeBox.GetComponent<ProfileBadge> ();
		this.addAchievement ();
		this.addBadges ();
	}

	public void addAchievement()
	{
		this.AchScript.AddAchievements (AchievementList);
	}

	public void addBadges()
	{
		this.BadgeScript.AddBadges (BadgeList);
	}

}
