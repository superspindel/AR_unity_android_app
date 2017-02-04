﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pageswapper : MonoBehaviour {

	[Header("Testing")]
	[SerializeField] private Stack<GameObject> _previousPages;

	[Header("Default / Current Active Page")]
	[SerializeField] private GameObject _activePage;

	[Header("Main View")]
	//public GameObject 	MainWindow;
	public GameObject 	ProfilePage;
	public GameObject 	AvalibleTaskPage;
	public GameObject 	ActiveTasksPage;
	public GameObject 	SettingsPage;
	public GameObject 	SpecificTaskPage;
	public GameObject 	LeaderBoardPage;

	[Header("PopUp View")]
	public GameObject 	PopUpWindow;

	void Start(){
		_previousPages = new Stack<GameObject>();
	}


// Functions for Navigation
	void Update() {
		// Listen for Back button on Android
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Back Pressed");
			goBack ();
		}
	}

	private void goBack(){
		unloadActivePage ();
		activePageBack ();
		if (this._activePage == ProfilePage) {
			GoToProfilePage ();
		}
		if (this._activePage == AvalibleTaskPage) {
			gotoAvalibleTasksPage ();
		}
		if (this._activePage == ActiveTasksPage) {
			gotoActiveTasksPage ();
		}
		if (this._activePage == SettingsPage) {
			gotoSettingsPage ();
		}
		if (this._activePage == SpecificTaskPage) {
			gotoSpecificTaskPage ("0"); // should not happen?
		}
	}

	private void activePageBack(){
		if (_previousPages.Count != 0) {
			unloadActivePage ();
			_activePage.SetActive (false);
			_activePage = _previousPages.Pop ();
		}
	}

	private void activePageForward(GameObject page){
		unloadActivePage ();
		_previousPages.Push (_activePage);
		_activePage.SetActive (false);
		_activePage = page;
		// limit size of stack / queue?
	}

	// unload assets and other page specific things
	private void unloadActivePage(){
		if (this._activePage == ProfilePage) {
			LeaveProfilePage ();
		}
		if (this._activePage == AvalibleTaskPage) {
			leaveAvalibleTasksPage ();
		}
		if (this._activePage == ActiveTasksPage) {
			leaveActiveTasksPage ();
		}
		if (this._activePage == SettingsPage) {
			leaveSettingsPage ();
		}
		if (this._activePage == SpecificTaskPage) {
			leaveSpecificTaskPage ();
		}
	}

	public void showLoadScreen(){
		
	}

	// EXAMPLE 
	// - Get script from Page
	// - Get data from Model / API
	// - Show loading page while waiting
	// - run enterPage on page
	// - activate page?

// Main View
	// ProfilePage
	public void GoToProfilePage()
	{
		ProfileView Script = ProfilePage.GetComponent<ProfileView> ();
		DataStore.Get<User> ("12345", o => {
			Script.EnterPage(o);			
		});
	}

	private void LeaveProfilePage()
	{
		ProfileView Script = ProfilePage.GetComponent<ProfileView> ();
		Script.LeavePage ();
	}

	public void GoToLeaderboardPage()
	{
		LeaderBoardView Script = LeaderBoardPage.GetComponent<LeaderBoardView> ();
		DataStore.List<Leaderboard> (list => {
			Script.EnterPage(list as List<Leaderboard>);
		});
	}

	private void LeaveLeaderboardPage()
	{
		LeaderBoardView Script = LeaderBoardPage.GetComponent<LeaderBoardView> ();
		Script.LeavePage ();
	}
		


	// AvalibleTaskPage
	public void gotoAvalibleTasksPage(){

	}

	private void leaveAvalibleTasksPage(){

	}

	// ActiveTasksPage
	public void gotoActiveTasksPage(){
		
	}

	private void leaveActiveTasksPage(){

	}

	// SettingsPage
	public void gotoSettingsPage(){
		SetupMenu Script = SettingsPage.GetComponent<SetupMenu> ();
		// Read settings file
		Script.EnterPage();
	}

	private void leaveSettingsPage(){
		SetupMenu Script = SettingsPage.GetComponent<SetupMenu> ();
		// Write to settings file
		Script.LeavePage();
	}

	// SpecificTaskPage
	public void gotoSpecificTaskPage(string taskId){
		activePageForward (this.SpecificTaskPage);
		this._activePage.SetActive (false);
		this.SpecificTaskPage.SetActive (true);
	}

	private void leaveSpecificTaskPage(){

	}

// PopUp View
	public void gotoPopup(PopUpType type, string panelTitle, string title, string content){
		this.gameObject.SetActive (true);

	}

	public void leavePopup(){
		transform.gameObject.SetActive (false);
	}
}
