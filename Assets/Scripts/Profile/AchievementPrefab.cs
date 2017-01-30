using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPrefab : MonoBehaviour {

	public Text achText;
	public Button buttonComponent;
	private Achievement achievement;
	public int id { get; private set;}


	public void Setup(AchievementObject achObj, Achievement ach)
	{
		this.achText.text = achObj.achievementText;
		this.id = achObj.id;
		this.achievement = ach;
	}
	void Start()
	{
		this.buttonComponent.onClick.AddListener (HandleClick);
	}

	public void HandleClick()
	{
		this.achievement.removeFromList (this.id);
	}


}
