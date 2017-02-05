using System.Collections;
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
			GotoAvalibleTasksPage ();
		if (this._activePage == ActiveTasksPage)
			GotoActiveTasksPage ();
		if (this._activePage == SettingsPage)
			GotoSettingsPage ();
		if (this._activePage == SpecificTaskPage)
			GotoSpecificTaskPage ("0"); // TODO: should not happen?
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
		ProfileView script = ProfilePage.GetComponent<ProfileView> ();
		DataStore.Get<User> ("12345", o => {
			script.EnterPage(o);			
		});
	}

	private void _leaveProfilePage()
	{
		ProfileView script = ProfilePage.GetComponent<ProfileView> ();
		script.LeavePage ();
	}

	public void GoToLeaderboardPage()
	{
		LeaderBoardView script = LeaderBoardPage.GetComponent<LeaderBoardView> ();
		DataStore.List<Leaderboard> (list => {
			script.EnterPage(list as List<Leaderboard>);
		});
	}

	private void _leaveLeaderboardPage()
	{
		LeaderBoardView script = LeaderBoardPage.GetComponent<LeaderBoardView> ();
		script.LeavePage ();
	}
		


	// AvalibleTaskPage
	public void GotoAvalibleTasksPage(){

	}

	private void _leaveAvalibleTasksPage(){

	}

	// ActiveTasksPage
	public void GotoActiveTasksPage(){
		
	}

	private void _leaveActiveTasksPage(){

	}

	// SettingsPage
	public void GotoSettingsPage(){
		SetupMenu script = SettingsPage.GetComponent<SetupMenu> ();
		// Read settings file
		script.EnterPage();
	}

	private void _leaveSettingsPage(){
		SetupMenu script = SettingsPage.GetComponent<SetupMenu> ();
		// Write to settings file
		script.LeavePage();
	}

	// SpecificTaskPage
	public void GotoSpecificTaskPage(string taskId){
		_activePageForward (this.SpecificTaskPage);
		SpecificTaskView script = SpecificTaskPage.GetComponent<SpecificTaskView> ();

		DataStore.Get<Task> (taskId, task => {
			// if task gets updated??
			task.Updated += i =>
			{
				script.UpdatePage(task);
			};
			script.EnterPage(task);			
		});
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

	public void LeavePopup(){
		PopUpWindow.GetComponent<PopUp>().ClosePopup ();
	}
}
