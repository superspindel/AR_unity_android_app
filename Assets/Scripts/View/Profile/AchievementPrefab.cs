using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPrefab : MonoBehaviour {

	public Text AchText;
	public Button ButtonComponent;
	private ProfileAchievement _ProfileAch;
	private string _UserId { get; set;}
	private Pageswapper _PageSwapper;
	private Achievement _Achievement;

	void Awake()
	{
		this._PageSwapper = GameObject.FindWithTag ("Pageswapper").GetComponent<Pageswapper> ();
		this.AchText = this.transform.FindChild ("Text").GetComponent<Text> ();
		this.ButtonComponent = this.transform.GetComponent<Button> ();
	}

	// Setup of the prefab
	public void Setup(Achievement Achiev, ProfileAchievement ProfAch)
	{
		this.AchText.text = Achiev.Information;
		this._UserId = Achiev.UserId.ToString ();
		this._ProfileAch = ProfAch;
		this._Achievement = Achiev;
		this.ButtonComponent.onClick.AddListener (this.PopUp);
	}
	private void PopUp()
	{
		this._PageSwapper.OpenPopup_General (this._Achievement.Title, this.GetInformation ());
	}

	private string GetInformation()
	{
		return this._Achievement.Information +" "+ this._Achievement.Completed.ToString() +" completed out of " + this._Achievement.Needed.ToString();
	}
}
