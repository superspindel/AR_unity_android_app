﻿using System.Collections;
using System.Collections.Generic;
using App;
using UnityEngine;
using UnityEngine.UI;

// TODO: Change code be able to go back with ID
public class Page {
	GameObject PageObject;
	string Id;

	public Page(GameObject page, string id){
		this.PageObject = page;
		this.Id = id;
	}

}

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
	private PopUp		_popup;

	void Start(){
		_previousPages 	= new Stack<GameObject>();
		_popup 		= PopUpWindow.GetComponent<PopUp> ();
	}
		
	void Update() {
		// Listen for Back button on Android
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Back Pressed");
			_goBack ();
		}
	}

	private void _goBack(){
		_activePageBack ();
		if (this._activePage == ProfilePage)
			GoToProfilePage ();
		if (this._activePage == AvalibleTaskPage)
			gotoAvalibleTasksPage ();
		if (this._activePage == ActiveTasksPage)
			gotoActiveTasksPage ();
		if (this._activePage == SettingsPage)
			gotoSettingsPage ();
		if (this._activePage == SpecificTaskPage)
			//gotoSpecificTaskPage ();//"0"); // TODO: should not happen?
		if (this._activePage == LeaderBoardPage)
			GoToLeaderboardPage ();
	}

	private void _activePageBack(){
		if (_previousPages.Count != 0) {
			_unloadActivePage ();
			_activePage = _previousPages.Pop ();
		}
	}

	private void _activePageForward(GameObject page){
		_unloadActivePage ();
		_previousPages.Push (_activePage);
		_activePage = page;
		// limit size of stack / queue?
	}

	// unload assets and other page specific things
	private void _unloadActivePage(){
		if (this._activePage == ProfilePage)
			_leaveProfilePage ();
		else if (this._activePage == AvalibleTaskPage)
			_leaveAvalibleTasksPage ();
		else if (this._activePage == ActiveTasksPage)
			_leaveActiveTasksPage ();
		else if (this._activePage == SettingsPage)
			_leaveSettingsPage ();
		else if (this._activePage == SpecificTaskPage)
			_leaveSpecificTaskPage ();
		else if (this._activePage == LeaderBoardPage)
			_leaveLeaderboardPage ();
	}

	private void _showLoadScreen(){
		
	}

// Main View
	// ProfilePage
	public void GoToProfilePage()
	{
		_activePageForward (this.ProfilePage);
		ProfileView Script = ProfilePage.GetComponent<ProfileView> ();
		DataStore.Get<User> (Settings.application.UserID.ToString(), o => {
			if(o.Available)
			{
				Script.EnterPage(o);
			}
			else
			{
				Script.NotAvailable();
			}
		});
	}

	private void _leaveProfilePage()
	{
		ProfileView Script = ProfilePage.GetComponent<ProfileView> ();
		Script.LeavePage ();
	}

	public void GoToLeaderboardPage()
	{
		_activePageForward (this.LeaderBoardPage);
		LeaderboardView Script = LeaderBoardPage.GetComponent<LeaderboardView> ();
		DataStore.List<Leaderboard> (Settings.application.UserID.ToString(), list => {
			Script.EnterPage(list as List<Leaderboard>);
		});
	}

	private void _leaveLeaderboardPage()
	{
		LeaderboardView Script = LeaderBoardPage.GetComponent<LeaderboardView> ();
		Script.LeavePage ();
	}
		


	// AvalibleTaskPage
	public void gotoAvalibleTasksPage(){
		_activePageForward (this.AvalibleTaskPage);
		TaskScrollList script = AvalibleTaskPage.GetComponent<TaskScrollList> ();
		DataStore.List<Task> (list => {
			script.EnterPage(list as List<Task>);
		});
	}

	private void _leaveAvalibleTasksPage(){
		TaskScrollList script = AvalibleTaskPage.GetComponent<TaskScrollList> ();
		script.LeavePage ();
	}

	// ActiveTasksPage
	public void gotoActiveTasksPage(){
		_activePageForward (this.ActiveTasksPage);
		ActiveTasksSetup script = ActiveTasksPage.GetComponent<ActiveTasksSetup> ();
		DataStore.List<Task> ("me", list => { // removed "me", lists => // Emil
			script.EnterPage(list as List<Task>);
		});
	}

	private void _leaveActiveTasksPage(){
		ActiveTasksSetup activetaskpage = ActiveTasksPage.GetComponent<ActiveTasksSetup> ();
		activetaskpage.LeavePage ();
	}

	// SettingsPage
	public void gotoSettingsPage(){
		_activePageForward (this.SettingsPage);
		SetupMenu Script = SettingsPage.GetComponent<SetupMenu> ();
		// Read settings file
		Script.EnterPage();
	}

	private void _leaveSettingsPage(){
		SetupMenu Script = SettingsPage.GetComponent<SetupMenu> ();
		// Write to settings file
		Script.LeavePage();
	}

	// SpecificTaskPage
	public void gotoSpecificTaskPage(string taskId){
		SpecificTaskView script = SpecificTaskPage.GetComponent<SpecificTaskView> ();

		// show loading page

		DataStore.Get<Task> ("1", task => {
			if(task.Available){
				_activePageForward (this.SpecificTaskPage);
				script.EnterPage(task);
			}else{
				OpenPopup_Error("Data Error", "Can't find data about the specific task with id: " + task.Id);
			}
		})
		;
	}

	private void _leaveSpecificTaskPage(){
		SpecificTaskView script = SpecificTaskPage.GetComponent<SpecificTaskView> ();
		script.LeavePage ();
	}

// PopUp View
	public void OpenPopup_SubTaskInformation(string subTaskId){
		DataStore.Get<SubTask> (subTaskId, subTask => {
			// stuff
			_popup.OpenSubTaskInformationPopup(subTask);
		});
	}

	public void OpenPopup_General(string title, string content){
		_popup.OpenGeneralPopup (title, content);
	}

	public void OpenPopup_Error(string title, string content){
		_popup.OpenErrorPopup (title, content);
	}

	public void LeavePopup(){
		PopUpWindow.GetComponent<PopUp>().ClosePopup ();
	}

}
