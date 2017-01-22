using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

	public Slider LevelSlider;
	public Text XpNow;
	public Text XpLevel;
	public Text LevelText;

	private int xp;
	private int maxXp;
	private int level;

	// Use this for initialization
	void Start () {
		xp = 0;
		maxXp = 10;
		level = 1;
		updateDisplay ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void continousUpdate()
	{
		xp = xp + 1;
		if (xp == maxXp) 
		{
			maxXp = maxXp * 2;
			xp = 0;
			level = level + 1;
		}
		updateDisplay ();
	}

	private void updateDisplay()
	{
		XpNow.text = xp.ToString ();
		XpLevel.text = maxXp.ToString ();
		LevelText.text = "Level:\n"+level.ToString ();
		LevelSlider.value = xp;
		LevelSlider.maxValue = maxXp;
	}

	public void setxp (int addXP) 
	{
		xp = xp + addXP;
		if (xp >= maxXp) 
		{
			xp = xp - maxXp;
			maxXp = maxXp * 2;

		}
	}

	private void addLevel()
	{
		level = level + 1;
	}
		
}
