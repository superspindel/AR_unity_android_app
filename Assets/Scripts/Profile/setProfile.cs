using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Profile
{
	public int id { get; private set;}
	public Sprite profImg { get; private set;} 		// how?
	public string name { get; private set;}
	public int dailyScore { get; private set;}
	public int TotalScore { get; private set;}
	public int totalLevel { get; private set;}

	public int[] badgeArray { get; private set;}
	public int[] achArray { get; private set;}

	// Badge data
	// store on server? int for example: tasksCompleted, nrOfDaysInTime etc.;
	// Server listens for changes in statistics sends badge id

	// Ach data
	//public List<int> achiId
	//public List<int> badgeId

	public Profile(Sprite img, string profName, int dScore, int tScore, int tLevel, int[] badgeArray, int[] achArray)
	{
		this.profImg = img;
		this.name = profName;
		this.dailyScore = dScore;
		this.TotalScore = tScore;
		this.totalLevel = tLevel;
		this.badgeArray = badgeArray;
		this.achArray = achArray;
	}
}


public class setProfile : MonoBehaviour {

	public Image profileImage;
	public Text nameField;
	public Text DailyScoreField;
	public Text TotalScoreField;
	public Transform slider;
	public SliderScript slscrpt{ get; private set; }
	public List<Profile> profileList;

	public void Start()
	{
		this.slscrpt = slider.GetComponent<SliderScript> ();
		this.setProfileInfo (profileList [0]);
	}
		
	public void setProfileInfo(Profile playerProfile)
	{
		this.profileImage.sprite = playerProfile.profImg;
		this.setName (playerProfile.name);
		this.setScore (playerProfile.dailyScore, playerProfile.TotalScore);
		this.slscrpt.setSlider (playerProfile);
	}

	private void setName(string name)
	{
		nameField.text = "Name: \n" + name;
	}

	private void setScore(int dScore, int tScore)
	{
		DailyScoreField.text = "Daily: \n" + dScore.ToString ();
		TotalScoreField.text = "Total: \n" + tScore.ToString ();
	}

}
