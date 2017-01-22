using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class AchievementObject
{
	public int id;
	public string achievementText;
}


public class Achievement : MonoBehaviour {

	public List<AchievementObject> achievementObjectList;
	public Transform achievementPanel;
	public GameObject achievementGroup;
	public SimpleObjectPool achievementObjectPool;

	public void addToList(AchievementObject obj)
	{
		achievementObjectList.Add (obj);
	}

	public void resetDisplay()
	{
		RemoveAchievements ();
		addAchievements ();
	}

	public void removeFromList(int id)
	{
		for (int i = achievementObjectList.Count-1; i >= 0; i--) 
		{
			if (achievementObjectList [i].id == id) 
			{
				achievementObjectList.RemoveAt (i);
			}
		}
		resetDisplay ();
	}
	private void RemoveAchievements()
	{
		while (achievementPanel.childCount > 0)
		{
			GameObject toRemove = achievementPanel.GetChild(0).gameObject;
			achievementObjectPool.ReturnObject(toRemove);
		}
	}

	private void addAchievements()
	{
		for (int i = 0; i < achievementObjectList.Count; i++)
		{
			AchievementObject achObj = achievementObjectList [i];
			GameObject newAch = achievementObjectPool.GetObject ();
			newAch.transform.SetParent (achievementPanel);
			AchievementPrefab achPref = newAch.GetComponent<AchievementPrefab> ();
			achPref.Setup (achObj, this);
		}
	}
}
