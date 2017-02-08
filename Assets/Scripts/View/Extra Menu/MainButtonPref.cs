﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script associated with the main button prefab, will setup the values for the button and add the onClick event.
public class MainButtonPref : MonoBehaviour {
	private Text TextField;
	private Image ImageIcon;
	private ButtonGroupPref _parent; // Parent script to call for toggle.
	private Button Butncmp;

	void Awake()
	{
		this.Butncmp = transform.GetComponent<Button> ();
		this.TextField = transform.FindChild ("Text").GetComponent<Text> ();
		this.ImageIcon = transform.FindChild ("Icon").GetComponent<Image> ();
	}

	// Setup takes a title, a icon and the parent script.
	// Sets the gameobject variables and adds the onClick event.
	public void Setup(string title, Sprite icon, ButtonGroupPref parent)
	{
		ImageIcon.sprite = icon;
		TextField.text = title;
		this._parent = parent;
		Butncmp.onClick.RemoveAllListeners ();
		Butncmp.onClick.AddListener (HandleClick);
	}
	// Calls function in parent to toggle the submenugroups active variable.
	public void HandleClick()
	{
		this._parent.ToggleSubMenu ();
	}
}
