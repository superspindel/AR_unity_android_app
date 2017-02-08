using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProfileInfo : MonoBehaviour {

	private Image ProfileImage;
	private Text NameField;
	private Text DailyScoreField;
	private Text TotalScoreField;
	private SliderScript _Slscrpt{ get; set; }

	// initialize by getting the script from the slider game object
	void Awake()
	{
		this._Slscrpt = transform.FindChild ("ProfileText").FindChild ("Level").FindChild ("Slider").GetComponent<SliderScript> ();
		this.ProfileImage = transform.FindChild ("ProfilePicture").FindChild ("PictureSquare").FindChild ("Image").GetComponent<Image> ();
		this.NameField = transform.FindChild ("ProfileText").FindChild ("Name").GetComponent<Text> ();
		this.DailyScoreField = transform.FindChild ("ProfileText").FindChild ("DailyScore").GetComponent<Text> ();
		this.TotalScoreField = transform.FindChild ("ProfileText").FindChild ("TotalScore").GetComponent<Text> ();
	}

	// Set the profile view up with the information from the User object passed in
	// Setup the slider with the same user object
	public void SetProfileInfo(User PlayerProfile)
	{
		//this.ProfileImage.sprite = PlayerProfile.profImg;
		this.NameField.text = "Name: \n" + PlayerProfile.Name;
		this.DailyScoreField.text = "Daily: \n" + PlayerProfile.DailyScore.ToString ();
		this.TotalScoreField.text = "Total: \n" + PlayerProfile.TotalScore.ToString ();
		this._Slscrpt.SetSlider (PlayerProfile);
	}

}
