﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class ProfileBadge : MonoBehaviour {

	public Transform BadgeGroupPanel;
	public SimpleObjectPool BadgePool;

	/*
	public void resetDisplay()
	{
		this.RemoveBadges ();
		this.addBadges ();
	}
	*/

	public void RemoveBadges()
	{
		while (this.BadgeGroupPanel.childCount > 0) 
		{
			GameObject toRemove = BadgeGroupPanel.GetChild(0).gameObject;
			this.BadgePool.ReturnObject(toRemove);
		}
	}

	public void AddBadges(List<Badge> BadgeList)
	{
		foreach (Badge Bdg in BadgeList)
		{
			GameObject newBadge = this.BadgePool.GetObject ();
			newBadge.transform.SetParent (this.BadgeGroupPanel);
			BdgPref badgePref = newBadge.GetComponent<BdgPref> ();
			badgePref.Setup (Bdg, this);
		}
	}
}
