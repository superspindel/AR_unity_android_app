using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileScrollView : MonoBehaviour {

	public Transform achievementBox;
	public Transform profileInfo;
	public Transform BadgesBox;
	private Achievement achScript;
	private Badges badgeScript;
	private Badges badges;
	public List<AchievementObject> achievementObjectList;
	public List<BadgeObject> badgeObjectList;

	// Use this for initialization
	void Start () {
		this.achScript = achievementBox.GetComponent<Achievement> ();
		this.badgeScript = BadgesBox.GetComponent<Badges> ();
		this.addAchievement ();
		this.addBadges ();
	}

	public void addAchievement()
	{
		for (int i = 0; i < this.achievementObjectList.Count; i++)
		{
			AchievementObject obj = this.achievementObjectList [i];
			this.achScript.addToList (obj);
		}
		achScript.resetDisplay ();
	}

	public void addBadges()
	{
		for (int i = 0; i < this.badgeObjectList.Count; i++) 
		{
			BadgeObject obj = badgeObjectList [i];
			this.badgeScript.addToList (obj);
		}
		this.badgeScript.resetDisplay ();
	}

}
