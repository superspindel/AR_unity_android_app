using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BdgPref : MonoBehaviour {

	public Image BadgeIcon;
	public Button ButtonComponent;

	private ProfileBadge _Parent;
	private int _UserId;

	public BadgeDict BadgeDictionary;

	// Setup of the prefab
	public void Setup(Badge bdg, ProfileBadge profBdg)
	{
		this.BadgeIcon.sprite = BadgeDictionary.GetSprite (bdg.SpriteId);
		this._Parent = profBdg;
		this._UserId = bdg.userID;
	}
}
