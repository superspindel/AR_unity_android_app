using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Profile
{
	//private Sprite profImg;
	//private string name;
	//private int dailyScore;
	//private int TotalScore;
	//private int totalLevel;
	public int id;
	public Sprite profImg; 		// how?
	public string name;
	public int dailyScore;
	public int TotalScore;
	public int totalLevel;

	// Badge data
	// store on server? int for example: tasksCompleted, nrOfDaysInTime etc.;
	// Server listens for changes in statistics sends badge id

	// Ach data
	//public List<int> achiId
	//public List<int> badgeId

	public Profile(Sprite img, string profName, int dScore, int tScore, int tLevel)
	{
		profImg = img;
		name = profName;
		dailyScore = dScore;
		TotalScore = tScore;
		totalLevel = tLevel;
	}

	public Sprite getSprite()
	{
		return profImg;
	}

	public string getName()
	{
		return name;
	}

	public int getDailyScore()
	{
		return dailyScore;
	}

	public int getTotalScore()
	{
		return TotalScore;
	}

	public int getLevel()
	{
		return totalLevel;
	}
}


public class setProfile : MonoBehaviour {

	public Image profileImage;
	public Text nameField;
	public Text DailyScoreField;
	public Text TotalScoreField;
	public Transform slider;
	private SliderScript slscrpt;
	public List<Profile> profileList;

	public void Start()
	{
		slscrpt = slider.GetComponent<SliderScript> ();
		setProfileInfo (profileList [0]);
	}
		
	public void setProfileInfo(Profile playerProfile)
	{
		setImage (playerProfile.getSprite ());
		setName (playerProfile.getName ());
		setScore (playerProfile.getDailyScore (), playerProfile.getTotalScore ());
		slscrpt.setSlider (playerProfile);
	}

	private void setName(string name)
	{
		nameField.text = "Name: \n" + name;
	}

	private void setImage(Sprite image)
	{
		profileImage.sprite = image;
	}

	private void setScore(int dScore, int tScore)
	{
		DailyScoreField.text = "Daily: \n" + dScore.ToString ();
		TotalScoreField.text = "Total: \n" + tScore.ToString ();
	}

}
