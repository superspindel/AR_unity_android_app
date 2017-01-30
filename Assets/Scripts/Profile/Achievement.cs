using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class AchievementObject
{
	public int id { get; private set;}
	public string achievementText { get; private set;}
}


public class Achievement : MonoBehaviour {

	public List<AchievementObject> achievementObjectList;
	public Transform achievementPanel;
	public GameObject achievementGroup;
	public SimpleObjectPool achievementObjectPool;

	public void addToList(AchievementObject obj)
	{
		this.achievementObjectList.Add (obj);
	}

	public void resetDisplay()
	{
		this.RemoveAchievements ();
		this.addAchievements ();
	}

	public void removeFromList(int id)
	{
		for (int i = this.achievementObjectList.Count-1; i >= 0; i--) 
		{
			if (this.achievementObjectList [i].id == id) 
			{
				this.achievementObjectList.RemoveAt (i);
			}
		}
		resetDisplay ();
	}
	private void RemoveAchievements()
	{
		while (this.achievementPanel.childCount > 0)
		{
			GameObject toRemove = achievementPanel.GetChild(0).gameObject;
			this.achievementObjectPool.ReturnObject(toRemove);
		}
	}

	private void addAchievements()
	{
		for (int i = 0; i < this.achievementObjectList.Count; i++)
		{
			AchievementObject achObj = this.achievementObjectList [i];
			GameObject newAch = this.achievementObjectPool.GetObject ();
			newAch.transform.SetParent (this.achievementPanel);
			AchievementPrefab achPref = newAch.GetComponent<AchievementPrefab> ();
			achPref.Setup (achObj, this);
		}
	}
}
