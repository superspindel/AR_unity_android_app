﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class ProfileBadge : Prefab {

	public Transform BadgeGroupPanel;
	public SimpleObjectPool BadgePool;

	/*
	public void resetDisplay()
	{
		this.RemoveBadges ();
		this.addBadges ();
	}
	*/

	// Return object to the pool
	public override void ReturnChildren()
	{
		while (this.BadgeGroupPanel.childCount > 0) 
		{
			GameObject toRemove = BadgeGroupPanel.GetChild(0).gameObject;
			this.BadgePool.ReturnObject(toRemove);
		}
	}

	// Add objects from pool to the scene and call setup on them
	public void AddBadges(List<Badge> badgeList)
	{
		foreach (Badge bdg in badgeList)
		{
			GameObject newBadge = this.BadgePool.GetObject ();
			newBadge.transform.SetParent (this.BadgeGroupPanel);
			BdgPref badgePref = newBadge.GetComponent<BdgPref> ();
			badgePref.Setup (bdg, this);
		}
	}
}

