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

	void Start(){
		_previousPages = new Stack<GameObject>();
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
			gotoSpecificTaskPage ("0"); // TODO: should not happen?
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
			LeaveProfilePage ();
		else if (this._activePage == AvalibleTaskPage)
			leaveAvalibleTasksPage ();
		else if (this._activePage == ActiveTasksPage)
			leaveActiveTasksPage ();
		else if (this._activePage == SettingsPage)
			leaveSettingsPage ();
		else if (this._activePage == SpecificTaskPage)
			leaveSpecificTaskPage ();
	}

	private void _showLoadScreen(){
		
	}

// Main View
	// ProfilePage
	public void GoToProfilePage()
	{
		ProfileView script = ProfilePage.GetComponent<ProfileView> ();
		DataStore.Get<User> ("12345", o => {
			o.Updated += i =>
			{
				script.UpdatePage(o);
			};
			script.EnterPage(o);			
		});
	}

	private void LeaveProfilePage(){
		ProfileView script = ProfilePage.GetComponent<ProfileView> ();

	}

	public void GoToLeaderboardPage()
	{
		
	}

	private void LeaveLeaderboardPage()
	{
		
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

	}

	private void leaveSettingsPage(){

	}

	// SpecificTaskPage
	public void gotoSpecificTaskPage(string taskId){
		_activePageForward (this.SpecificTaskPage);
		SpecificTaskView script = SpecificTaskPage.GetComponent<SpecificTaskView> ();

		DataStore.Get<User> (taskId, task => {
			// if task gets updated??
			task.Updated += i =>
			{
				script.UpdatePage(task);
			};
			script.EnterPage(task);			
		});

		script.EnterPage ();
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
