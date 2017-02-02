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
	public SliderScript Slscrpt{ get; private set; }

	public void Start()
	{
		this.Slscrpt = Slider.GetComponent<SliderScript> ();
	}
		
	public void SetProfileInfo(Profile PlayerProfile)
	{
		this.ProfileImage.sprite = PlayerProfile.profImg;
		this.NameField.text = "Name: \n" + PlayerProfile.Name;
		this.DailyScoreField.text = "Daily: \n" + PlayerProfile.DailyScore.ToString ();
		this.TotalScoreField.text = "Total: \n" + PlayerProfile.TotalScore.ToString ();
		this.Slscrpt.setSlider (PlayerProfile);
	}

}
