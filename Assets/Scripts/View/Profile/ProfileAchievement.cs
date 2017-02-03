using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileAchievement : MonoBehaviour {

	public Transform achievementPanel;
	public GameObject achievementGroup;
	public SimpleObjectPool achievementObjectPool;

	/*
	public void resetDisplay()
	{
		this.RemoveAchievements ();
		this.AddAchievements ();
	}
	*/

	// Return the achievement prefabs to the pool
	private void RemoveAchievements()
	{
		while (this.achievementPanel.childCount > 0)
		{
			GameObject toRemove = achievementPanel.GetChild(0).gameObject;
			this.achievementObjectPool.ReturnObject(toRemove);
		}
	}
	// Add achievement prefabs from the pool to the scene and call setup on them
	public void AddAchievements(List<Achievement> AchievementList)
	{
		foreach( Achievement Ach in AchievementList)
		{
			GameObject newAch = this.achievementObjectPool.GetObject ();
			newAch.transform.SetParent (this.achievementPanel);
			AchievementPrefab achPref = newAch.GetComponent<AchievementPrefab> ();
			achPref.Setup (Ach, this);
		}
	}
}
