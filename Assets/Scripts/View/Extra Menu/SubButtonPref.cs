using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Script for sub button prefab. Setup for the gameobject to set the variables.
public class SubButtonPref : MonoBehaviour {

	private Text TextField;
	private SubMenuGroupPref _parentGroup;
	private Pageswapper _pageswapper;
	private Button _Button;

	void Awake()
	{
		this.TextField = transform.FindChild ("Text").GetComponent<Text> ();
	}


	// Setup for sub button prefab. Takes a sub menu object that contains the information and the script of the parent sub menu group.
	public void Setup(SubMenu sbMenu, SubMenuGroupPref parent)
	{
		this.TextField.text = sbMenu.Title;
		this._parentGroup = parent;
		this._pageswapper 		= GameObject.FindWithTag ("Pageswapper").GetComponent<Pageswapper>();
		this._Button = transform.GetComponent<Button> ();
		this._Button.onClick.RemoveAllListeners ();
		if (sbMenu.Target == "Leaderboard") 
		{
			this._Button.onClick.AddListener (this._pageswapper.GoToLeaderboardPage);
		} 
		else if (sbMenu.Target == "Specific") 
		{
			this._Button.onClick.AddListener (_specificTaskListener);
		}
		else if (sbMenu.Target == "Notification") 
		{
			this._Button.onClick.AddListener (_notificationTest);
		}
	}

	// GotoSpecificTask
	private void _specificTaskListener(){
		this._pageswapper.gotoSpecificTaskPage ("HardCodedId");
	}

	private void _notificationTest()
	{
		Assets.SimpleAndroidNotifications.Notification notification = new Assets.SimpleAndroidNotifications.Notification (NotificationType.FireAlarm, "WARNING FIRE IN THE AREA");
	}

	// TODO: 	onClick event to enter the settings view of this sub button.


}
