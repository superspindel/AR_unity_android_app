using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;



public class ProfileBadge : Prefab {

	private Transform BadgeGroupPanel;
	private SimpleObjectPool BadgePool;

	// Return object to the pool
	void Awake()
	{
		this.BadgePool = transform.parent.transform.FindChild ("BadgePool").GetComponent<SimpleObjectPool> ();
		this.BadgeGroupPanel = transform.FindChild ("BadgeGroup").transform;
	}

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
		if (badgeList != null) {
			foreach (Badge bdg in badgeList) {
				GameObject newBadge = this.BadgePool.GetObject ();
				newBadge.transform.SetParent (this.BadgeGroupPanel);
				BadgePrefab badgePref = newBadge.GetComponent<BadgePrefab> ();
				try {
					badgePref.Setup (bdg, this);
				} catch (Exception e) {
					Debug.Log (e.Message);
				}
			}
		}
	}
}

