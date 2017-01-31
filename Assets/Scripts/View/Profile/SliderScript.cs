using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

	public Slider LevelSlider;
	public Text XpNow;
	public Text XpLevel;
	public Text LevelText;

	public int xp { get; private set; }
	public int maxXp { get; private set; }
	public int userLevel { get; private set; }

	public void setSlider(Profile playerProf)
	{
		setData (playerProf.totalLevel, playerProf.TotalScore);
		updateDisplay ();
	}

	private void setData(int level, int totalXp)
	{
		int bottom = (10 * ((int)Mathf.Pow ((float)1.2, (float)(level - 1))));
		int top = (10 * ((int)Mathf.Pow ((float)1.2, (float)level)));
		maxXp = top - bottom;
		xp = totalXp - bottom;
		userLevel = level;
	}
		

	private void updateDisplay()
	{
		XpNow.text = xp.ToString ();
		XpLevel.text = maxXp.ToString ();
		LevelText.text = "Level:\n"+userLevel.ToString ();
		LevelSlider.maxValue = maxXp;
		LevelSlider.value = xp;
	}

	public void setxp (int addXP) 
	{
		xp += addXP;
		if (xp >= maxXp) 
		{
			xp = xp - maxXp;
			maxXp = (int)(maxXp * 1.2);
		}
		addLevel ();
	}

	private void addLevel()
	{
		userLevel += 1;
	}
		
}
