using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BdgPref : MonoBehaviour {

	public Image BadgeIcon;
	public Button ButtonComponent;

	private ProfileBadge _parent;
	private int _userId;

	public BadgeDict BadgeDictionary;

	// Setup of the prefab
	public void Setup(Badge bdg, ProfileBadge profBdg)
	{
		this.BadgeIcon.sprite = BadgeDictionary.GetSprite (bdg.SpriteId);
		this._parent = profBdg;
		this._userId = bdg.UserId;
	}
}
