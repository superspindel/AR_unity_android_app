using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// SliderScript will setup the slider aswell as handle the Level and XP for the current user.
public class SliderScript : MonoBehaviour {

	private Slider LevelSlider;
	private Text XpNow;
	private Text XpLevel;
	private Text LevelText;

	public int Xp { get; private set; }
	public int MaxXp { get; private set; }
	public int UserLevel { get; private set; }

	// Setslider takes a User object that contains the TotalLevel and TotalScore of the player
	// and sets the components of the view to match the user information and updates the display.

	void Awake()
	{
		this.LevelSlider = transform.GetComponent<Slider> ();
		this.XpNow = transform.FindChild ("currentXP").GetComponent<Text> ();
		this.XpLevel = transform.FindChild ("nextLevelXP").GetComponent<Text> ();
		this.LevelText = transform.parent.transform.GetComponent<Text> ();
	}


	public void SetSlider(User playerProf)
	{
		this.SetData (playerProf.TotalLevel, playerProf.TotalScore);
		this.UpdateDisplay ();
	}

	// SetData takes the user level and total xp as input
	// The function calculates the xp that the user has on the current level by calculating the Xp needed to gain the level and the Xp
	// needed to get to the next level. Then it sets the values in the object.
	private void SetData(int level, int totalXp)
	{
		int bottom = (10 * ((int)Mathf.Pow ((float)1.2, (float)(level)))); // The xp needed to reach the current level of the user
		int top = (10 * ((int)Mathf.Pow ((float)1.2, (float)level+1))); // The xp need to reach the next level
		this.MaxXp = top - bottom; // MaxXp of the slider should be the xp difference between the next level and the current level
		this.Xp = totalXp - bottom; // The current xp for the user on this level should be the total xp - the xp needed to get to the current level
		this.UserLevel = level;
	}


	private void UpdateDisplay()
	{
		this.XpNow.text = this.Xp.ToString (); // Sets the current xp text
		this.XpLevel.text = this.MaxXp.ToString (); // Sets the xp to next level text
		this.LevelText.text = "Level:\n"+this.UserLevel.ToString (); // Sets the current level text
		this.LevelSlider.maxValue = this.MaxXp; // Sets the sliders max value
		this.LevelSlider.value = this.Xp; // Sets the sliders current value
	}

	// AddXp takes the Xp gained from a task and updates the variables for the script.
	// TODO: Set the values of the User object instead so that the database can be updated with new Xp information?
	public void AddXp (int xpToAdd) 
	{
		this.Xp += xpToAdd;
		if (this.Xp >= this.MaxXp) 
		{
			this.Xp = this.Xp - this.MaxXp;
			this.MaxXp = (int)(this.MaxXp * 1.2);
		}
		this.AddLevel ();
	}
	// Adds a level to the object variable
	// TODO: Also update the user object instead?
	private void AddLevel()
	{
		this.UserLevel += 1;
	}

}
