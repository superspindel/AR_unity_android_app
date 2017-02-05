using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileAchievement : Prefab {

	public Transform AchievementPanel;
	public GameObject AchievementGroup;
	public SimpleObjectPool AchievementObjectPool;

	/*
	public void resetDisplay()
	{
		this.RemoveAchievements ();
		this.AddAchievements ();
	}
	*/

	// Return the achievement prefabs to the pool
	public override void ReturnChildren()
	{
		while (this.AchievementPanel.childCount > 0)
		{
			GameObject toRemove = AchievementPanel.GetChild(0).gameObject;
			this.AchievementObjectPool.ReturnObject(toRemove);
		}
	}
	// Add achievement prefabs from the pool to the scene and call setup on them
	public void AddAchievements(List<Achievement> achievementList)
	{
		foreach( Achievement ach in achievementList)
		{
			GameObject newAch = this.AchievementObjectPool.GetObject ();
			newAch.transform.SetParent (this.AchievementPanel);
			AchievementPrefab achPref = newAch.GetComponent<AchievementPrefab> ();
			achPref.Setup (ach, this);
		}
	}
}
