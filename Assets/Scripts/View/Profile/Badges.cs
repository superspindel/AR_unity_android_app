using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class BadgeObject
{
	public int id { get; private set;}
	public Sprite iconImage;
	public Color color;
}


public class Badges : MonoBehaviour {

	public List<BadgeObject> BadgeObjectList;
	public Transform BadgeGroupPanel;
	public SimpleObjectPool BadgePool;


	public void addToList(BadgeObject obj)
	{
		this.BadgeObjectList.Add (obj);
	}

	public void removeFromList(int id)
	{
		for (int i = this.BadgeObjectList.Count-1; i >= 0; i--) 
		{
			if (this.BadgeObjectList [i].id == id) 
			{
				this.BadgeObjectList.RemoveAt (i);
			}
		}
		resetDisplay ();
	}
	public void resetDisplay()
	{
		this.RemoveBadges ();
		this.addBadges ();
	}

	private void RemoveBadges()
	{
		while (this.BadgeGroupPanel.childCount > 0) 
		{
			GameObject toRemove = BadgeGroupPanel.GetChild(0).gameObject;
			this.BadgePool.ReturnObject(toRemove);
		}
	}

	void addBadges()
	{
		for (int i = 0; i < this.BadgeObjectList.Count; i++)
		{
			BadgeObject badgeObj = this.BadgeObjectList [i];
			GameObject newBadge = this.BadgePool.GetObject ();
			newBadge.transform.SetParent (this.BadgeGroupPanel);
			BadgePrefab badgePref = newBadge.GetComponent<BadgePrefab> ();
			badgePref.Setup (badgeObj, this);
		}
	}
}

