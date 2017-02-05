using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProfileInfo : MonoBehaviour {

	public Image ProfileImage;
	public Text NameField;
	public Text DailyScoreField;
	public Text TotalScoreField;
	public Transform Slider;
	private SliderScript _Slscrpt{ get; set; }

	// initialize by getting the script from the slider game object
	void Awake()
	{
		this._Slscrpt = Slider.GetComponent<SliderScript> ();
	}

	// Set the profile view up with the information from the User object passed in
	// Setup the slider with the same user object
	public void SetProfileInfo(User PlayerProfile)
	{
		this.ProfileImage.sprite = PlayerProfile.profImg;
		this.NameField.text = "Name: \n" + PlayerProfile.Name;
		this.DailyScoreField.text = "Daily: \n" + PlayerProfile.DailyScore.ToString ();
		this.TotalScoreField.text = "Total: \n" + PlayerProfile.TotalScore.ToString ();
		this._Slscrpt.SetSlider (PlayerProfile);
	}

}
