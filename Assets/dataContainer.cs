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

	public void removeAchievement(AchievementObject achObj)
	{
		achievementList.Remove (achObj);
	}

	public void addBadge(BadgeObject bdgObj)
	{
		badgeList.Remove (bdgObj);
	}


}
