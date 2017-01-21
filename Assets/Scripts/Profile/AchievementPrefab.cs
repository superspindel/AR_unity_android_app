using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPrefab : MonoBehaviour {

	public Text achText;


	public void Setup(AchievementObject achObj)
	{
		achText.text = achObj.achievementText;
	}



}
