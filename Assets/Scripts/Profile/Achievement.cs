using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class AchievementObject
{
	public string achievementText;
}


public class Achievement : MonoBehaviour {

	public List<AchievementObject> achievementObjectList;
	public Transform achievementPanel;
	public SimpleObjectPool achievementObjectPool;

	// Use this for initialization
	void Start () {
		addAchievements ();
	}


	void addAchievements()
	{
		for (int i = 0; i < achievementObjectList.Count; i++)
		{
			AchievementObject achObj = achievementObjectList [i];
			GameObject newAch = achievementObjectPool.GetObject ();
			newAch.transform.SetParent (achievementPanel);
			AchievementPrefab achPref = newAch.GetComponent<AchievementPrefab> ();
			achPref.Setup (achObj);
		}
	}
}
