﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboardTitlePref : MonoBehaviour {
	public Text titleText;

	public void Setup(string title)
	{
		this.titleText.text = title;
	}
}
