using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgePrefab : MonoBehaviour {

	public Image badgeIcon;
	// Use this for initialization
	public void Setup(BadgeObject badge)
	{
		badgeIcon.sprite = badge.iconImage;
	}
}
