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
		achScript = achievementBox.GetComponent<Achievement> ();
		badgeScript = BadgesBox.GetComponent<Badges> ();
		addAchievement ();
		addBadges ();
	}

	public void addAchievement()
	{
		for (int i = 0; i < achievementObjectList.Count; i++)
		{
			AchievementObject obj = achievementObjectList [i];
			achScript.addToList (obj);
			achScript.resetDisplay ();
		}
		achScript.resetDisplay ();
	}

	public void addBadges()
	{
		for (int i = 0; i < badgeObjectList.Count; i++) 
		{
			BadgeObject obj = badgeObjectList [i];
			badgeScript.addToList (obj);
			badgeScript.resetDisplay ();
		}
	}

}
