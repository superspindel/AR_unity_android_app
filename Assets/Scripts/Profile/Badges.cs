using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class BadgeObject
{
	public int id;
	public Sprite iconImage;
}


public class Badges : MonoBehaviour {

	public List<BadgeObject> BadgeObjectList;
	public Transform BadgeGroupPanel;
	public SimpleObjectPool BadgePool;


	public void addToList(BadgeObject obj)
	{
		BadgeObjectList.Add (obj);
	}

	public void removeFromList(int id)
	{
		for (int i = BadgeObjectList.Count-1; i >= 0; i--) 
		{
			if (BadgeObjectList [i].id == id) 
			{
				BadgeObjectList.RemoveAt (i);
			}
		}
		resetDisplay ();
	}
	public void resetDisplay()
	{
		RemoveBadges ();
		addBadges ();
	}

	private void RemoveBadges()
	{
		while (BadgeGroupPanel.childCount > 0) 
		{
			GameObject toRemove = BadgeGroupPanel.GetChild(0).gameObject;
			BadgePool.ReturnObject(toRemove);
		}
	}

	void addBadges()
	{
		for (int i = 0; i < BadgeObjectList.Count; i++)
		{
			BadgeObject badgeObj = BadgeObjectList [i];
			GameObject newBadge = BadgePool.GetObject ();
			newBadge.transform.SetParent (BadgeGroupPanel);
			BadgePrefab badgePref = newBadge.GetComponent<BadgePrefab> ();
			badgePref.Setup (badgeObj, this);
		}
	}
}

