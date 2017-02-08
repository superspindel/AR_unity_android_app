using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardTitlePref : MonoBehaviour {
	private Text TitleText;

	public void Setup(string title)
	{
		this.TitleText.text = title;
	}

	void Awake()
	{
		this.TitleText = transform.FindChild ("Text").GetComponent<Text> ();
	}
}
