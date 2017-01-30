using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgePrefab : MonoBehaviour {

	public Image badgeIcon;
	public Button buttonComponent;
	public Badges badges;
	public int id { get; private set;}
	// Use this for initialization
	public void Setup(BadgeObject badge, Badges badgeInstance)
	{
		this.badgeIcon.sprite = badge.iconImage;
		this.id = badge.id;
		this.badges = badgeInstance;
		this.badgeIcon.color = badge.color;
	}

	void Start()
	{
		this.buttonComponent.onClick.AddListener (HandleClick);
	}

	public void HandleClick()
	{
		this.badges.removeFromList (this.id);
	}

}
