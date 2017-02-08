using System.Collections;
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

	[Header("<< PRIVATE >> Current Active Page")]
	[SerializeField] private GameObject _activePage;

	[Header("Content Panel in Main Scroll View")]
	public GameObject 	MainContentPanel;

	// childs to MainContentPanel
	private GameObject 	_profilePage;
	private GameObject 	_avalibleTaskPage;
	private GameObject 	_activeTasksPage;
	private GameObject 	_settingsPage;
	private GameObject 	_specificTaskPage;
	private GameObject 	_leaderBoardPage;

	[Header("Content Panel in PopUp Scroll View")]
	public GameObject 	PopUpGameObject;
	private PopUp		_popupScript;

	void Awake(){
		_previousPages 		= new Stack<GameObject>();

		_profilePage 		= MainContentPanel.transform.FindChild ("ProfilePage").gameObject;
		_avalibleTaskPage	= MainContentPanel.transform.FindChild ("Available Tasks").gameObject; 
		_activeTasksPage	= MainContentPanel.transform.FindChild ("Active Tasks").gameObject;
		_settingsPage		= MainContentPanel.transform.FindChild ("MenuPanel").gameObject;
		_specificTaskPage	= MainContentPanel.transform.FindChild ("Specific Task View").gameObject;
		_leaderBoardPage	= MainContentPanel.transform.FindChild ("LeaderBoard").gameObject;


		_popupScript 			= PopUpGameObject.GetComponent<PopUp> ();

		PopUpGameObject.SetActive (true);
		PopUpGameObject.SetActive (false);
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
		if (this._activePage == _profilePage)
			GoToProfilePage ();
		if (this._activePage == _avalibleTaskPage)
			gotoAvalibleTasksPage ();
		if (this._activePage == _activeTasksPage)
			gotoActiveTasksPage ();
		if (this._activePage == _settingsPage)
			gotoSettingsPage ();
		if (this._activePage == _specificTaskPage)
			gotoSpecificTaskPage ("0"); // TODO: should not happen?
		if (this._activePage == _leaderBoardPage)
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
		if (this._activePage == _profilePage)
			_leaveProfilePage ();
		else if (this._activePage == _avalibleTaskPage)
			_leaveAvalibleTasksPage ();
		else if (this._activePage == _activeTasksPage)
			_leaveActiveTasksPage ();
		else if (this._activePage == _settingsPage)
			_leaveSettingsPage ();
		else if (this._activePage == _specificTaskPage)
			_leaveSpecificTaskPage ();
		else if (this._activePage == _leaderBoardPage)
			_leaveLeaderboardPage ();
	}

	private void _showLoadScreen(){
		
	}

// Main View
	// ProfilePage
	public void GoToProfilePage()
	{
		_activePageForward (this._profilePage);
		ProfileView Script = _profilePage.GetComponent<ProfileView> ();
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
		ProfileView Script = _profilePage.GetComponent<ProfileView> ();
		Script.LeavePage ();
	}

	public void GoToLeaderboardPage()
	{
		_activePageForward (this._leaderBoardPage);
		LeaderboardView Script = _leaderBoardPage.GetComponent<LeaderboardView> ();
		DataStore.List<Leaderboard> (Settings.application.UserID.ToString(), list => {
			Script.EnterPage(list as List<Leaderboard>);
		});
	}

	private void _leaveLeaderboardPage()
	{
		LeaderboardView Script = _leaderBoardPage.GetComponent<LeaderboardView> ();
		Script.LeavePage ();
	}
		


	// AvalibleTaskPage
	public void gotoAvalibleTasksPage(){
		_activePageForward (this._avalibleTaskPage);
		TaskScrollList script = _avalibleTaskPage.GetComponent<TaskScrollList> ();
		DataStore.List<Task> (list => {
			script.EnterPage(list as List<Task>);
		});
	}

	private void _leaveAvalibleTasksPage(){
		TaskScrollList script = _avalibleTaskPage.GetComponent<TaskScrollList> ();
		script.LeavePage ();
	}

	// ActiveTasksPage
	public void gotoActiveTasksPage(){
		_activePageForward (this._activeTasksPage);
		ActiveTasksSetup script = _activeTasksPage.GetComponent<ActiveTasksSetup> ();
		DataStore.List<Task> ("me", list => { // removed "me", lists => // Emil
			script.EnterPage(list as List<Task>);
		});
	}

	private void _leaveActiveTasksPage(){
		ActiveTasksSetup activetaskpage = _activeTasksPage.GetComponent<ActiveTasksSetup> ();
		activetaskpage.LeavePage ();
	}

	// SettingsPage
	public void gotoSettingsPage(){
		_activePageForward (this._settingsPage);
		SetupMenu Script = _settingsPage.GetComponent<SetupMenu> ();
		// Read settings file
		Script.EnterPage();
	}

	private void _leaveSettingsPage(){
		SetupMenu Script = _settingsPage.GetComponent<SetupMenu> ();
		// Write to settings file
		Script.LeavePage();
	}

	// SpecificTaskPage
	public void gotoSpecificTaskPage(string taskId){
		SpecificTaskView script = _specificTaskPage.GetComponent<SpecificTaskView> ();

		// show loading page

		DataStore.Get<Task> ("1", task => {
			if(task.Available){
				_activePageForward (this._specificTaskPage);
				script.EnterPage(task);
			}else{
				OpenPopup_Error("Data Error", "Can't find data about the specific task with id: " + task.Id);
			}
		})
		;
	}

	private void _leaveSpecificTaskPage(){
		SpecificTaskView script = _specificTaskPage.GetComponent<SpecificTaskView> ();
		script.LeavePage ();
	}

// PopUp View
	public void OpenPopup_SubTaskInformation(string subTaskId){
		DataStore.Get<SubTask> (subTaskId, subTask => {
			// stuff
			_popupScript.OpenSubTaskInformationPopup(subTask);
		});
	}

	public void OpenPopup_General(string title, string content){
		_popupScript.OpenGeneralPopup (title, content);
	}

	public void OpenPopup_Error(string title, string content){
		_popupScript.OpenErrorPopup (title, content);
	}

	public void LeavePopup(){
		PopUpGameObject.GetComponent<PopUp>().ClosePopup ();
	}

}
