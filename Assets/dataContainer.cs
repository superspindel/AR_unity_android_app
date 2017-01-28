using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataContainer : MonoBehaviour {
	public List<AchievementObject> achievementList;
	public List<BadgeObject> badgeList;
	public Profile activeProfile;

	public ArrayList settingsArray;

	public List<AchievementObject> getAchievementList()
	{
		return this.achievementList;
	}

	public List<BadgeObject> getBadgeList()
	{
		return this.badgeList;
	}

	public void addAchievement(AchievementObject achObj)
	{
		this.achievementList.Add (achObj);
	}

	public void setAchievementList(List<AchievementObject> newList)
	{
		this.achievementList = newList;
	}

	public void removeAchievement(AchievementObject achObj)
	{
		this.achievementList.Remove (achObj);
	}

	public void addBadge(BadgeObject bdgObj)
	{
		this.badgeList.Add (bdgObj);
	}

	public void setBadgeList(List<BadgeObject> newList)
	{
		this.badgeList = newList;
	}

	public void removeBadge(BadgeObject bdgObj)
	{
		this.badgeList.Remove (bdgObj);
	}

	public Profile getProfile()
	{
		return activeProfile;
	}

	public void setProfile(Profile newProfile)
	{
		this.activeProfile = newProfile;
	}

}
