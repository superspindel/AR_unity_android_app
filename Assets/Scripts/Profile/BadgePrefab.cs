using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgePrefab : MonoBehaviour {

	public Image badgeIcon;
	public Button buttonComponent;
	public Badges badges;
	public int id;
	// Use this for initialization
	public void Setup(BadgeObject badge, Badges badgeInstance)
	{
		badgeIcon.sprite = badge.iconImage;
		id = badge.id;
		badges = badgeInstance;
	}

	void Start()
	{
		buttonComponent.onClick.AddListener (HandleClick);
	}

	public void HandleClick()
	{
		badges.removeFromList (this.id);
	}

}
