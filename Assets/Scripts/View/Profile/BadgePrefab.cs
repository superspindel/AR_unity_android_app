using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgePrefab : MonoBehaviour {

	private Image BadgeIcon;
	private Button ButtonComponent;

	private ProfileBadge _Parent;
	private Badge _Badge;
	private Pageswapper _PageSwapper;

	void Awake()
	{
		this._PageSwapper = GameObject.FindWithTag ("Pageswapper").GetComponent<Pageswapper> ();
		this.ButtonComponent = transform.GetComponent<Button> ();
		this.BadgeIcon = transform.GetComponent<Image> ();
	}

	// Setup of the prefab
	public void Setup(Badge Bdg, ProfileBadge ProfBdg)
	{
		this.BadgeIcon.sprite = BadgeDict.GetSprite (Bdg.SpriteId);
		this._Parent = ProfBdg;
		this._Badge = Bdg;
		this.ButtonComponent.onClick.AddListener (this.PopUp);
	}

	private void PopUp()
	{
		this._PageSwapper.OpenPopup_General (this._Badge.Title, this.GetInformation());
	}

	private string GetInformation()
	{
		string Information = this._Badge.Information;
		if (this._Badge.DateFinished != null)
		{
			Information += "\n You have finished this badge. Completion date was " + this._Badge.DateFinished.ToString ();
		}
		else
		{
			Information += "\n You have completed " + this._Badge.Completed.ToString () + " out of " + this._Badge.Maximum.ToString () + ".";
		}
		return Information;
	}
}
