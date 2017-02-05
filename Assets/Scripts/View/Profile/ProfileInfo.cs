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
	private SliderScript Slscrpt{ get; set; }

	// initialize by getting the script from the slider game object
	void Awake()
	{
		this.Slscrpt = Slider.GetComponent<SliderScript> ();
	}

	// Set the profile view up with the information from the User object passed in
	// Setup the slider with the same user object
	public void SetProfileInfo(User playerProfile)
	{
		this.ProfileImage.sprite = playerProfile.ProfImg;
		this.NameField.text = "Name: \n" + playerProfile.Name;
		this.DailyScoreField.text = "Daily: \n" + playerProfile.DailyScore.ToString ();
		this.TotalScoreField.text = "Total: \n" + playerProfile.TotalScore.ToString ();
		this.Slscrpt.SetSlider (playerProfile);
	}

}
