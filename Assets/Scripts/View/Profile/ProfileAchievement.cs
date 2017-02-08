using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProfileAchievement : Prefab {

	private Transform AchievementPanel;
	private GameObject AchievementGroup;
	private SimpleObjectPool AchievementObjectPool;

	void Awake()
	{
		this.AchievementPanel = this.transform;
		this.AchievementGroup = transform.FindChild ("AchievementGroup").gameObject;
		this.AchievementObjectPool = transform.parent.transform.FindChild ("AchievementPool").GetComponent<SimpleObjectPool> ();
	}

	// Return the achievement prefabs to the pool
	public override void ReturnChildren()
	{
		while (this.AchievementGroup.transform.childCount > 0)
		{
			GameObject toRemove = AchievementGroup.transform.GetChild(0).gameObject;
			this.AchievementObjectPool.ReturnObject(toRemove);
		}
	}
	// Add achievement prefabs from the pool to the scene and call setup on them
	public void AddAchievements(List<Achievement> achievementList)
	{
		foreach(Achievement ach in achievementList)
		{
			GameObject newAch = this.AchievementObjectPool.GetObject ();
			newAch.transform.SetParent (this.AchievementGroup.transform);
			AchievementPrefab achPref = newAch.GetComponent<AchievementPrefab> ();
			try
			{
				achPref.Setup (ach, this);
			}
			catch(Exception e) 
			{
				Debug.Log (e.Message);
			}
		}
	}
}
