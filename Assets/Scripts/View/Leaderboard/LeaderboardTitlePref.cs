using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardTitlePref : MonoBehaviour {
	public Text TitleText;

	public void Setup(string title)
	{
		this.TitleText.text = title;
	}
}
