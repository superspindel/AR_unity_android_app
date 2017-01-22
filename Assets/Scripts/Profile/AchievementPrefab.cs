using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPrefab : MonoBehaviour {

	public Text achText;
	public Button buttonComponent;
	private Achievement achievement;
	private int id;


	public void Setup(AchievementObject achObj, Achievement ach)
	{
		achText.text = achObj.achievementText;
		id = achObj.id;
		achievement = ach;
	}
	void Start()
	{
		buttonComponent.onClick.AddListener (HandleClick);
	}

	public void HandleClick()
	{
		achievement.removeFromList (this.id);
	}


}
