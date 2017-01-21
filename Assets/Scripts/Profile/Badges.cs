using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class BadgeObject
{
	public Sprite iconImage;
}


public class Badges : MonoBehaviour {

	public List<BadgeObject> BadgeObjectList;
	public Transform BadgeGroupPanel;
	public SimpleObjectPool BadgePool;

	void Start () {
		addBadges ();
	}

	void addBadges()
	{
		for (int i = 0; i < BadgeObjectList.Count; i++)
		{
			BadgeObject badgeObj = BadgeObjectList [i];
			GameObject newBadge = BadgePool.GetObject ();
			newBadge.transform.SetParent (BadgeGroupPanel);
			BadgePrefab badgePref = newBadge.GetComponent<BadgePrefab> ();
			badgePref.Setup (badgeObj);
		}
	}
}

