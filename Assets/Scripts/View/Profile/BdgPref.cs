using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BdgPref : MonoBehaviour {

	public Image BadgeIcon;
	public Button ButtonComponent;
	public ProfileBadge Parent;
	public BadgeDict BadgeDictionary;

	// Use this for initialization
	public void Setup(Badge bdg, ProfileBadge profBdg)
	{
		this.BadgeIcon.sprite = BadgeDictionary.GetSprite (bdg.SpriteId);
		this.Parent = profBdg;
	}
}
