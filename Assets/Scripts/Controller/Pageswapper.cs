using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pageswapper : MonoBehaviour {

	[Header("Testing")]
	public Stack<GameObject> previousPages;

	[Header("Default / Current Active Page")]
	public GameObject activePage;

	[Header("Main View")]
	public GameObject mainWindow; 
	public GameObject profilePage;
	public GameObject avalibleTaskPage;
	public GameObject activeTasksPage;
	public GameObject settingsPage;
	public GameObject specificTaskPage;

	[Header("PopUp View")]
	public GameObject popUpWindow;

	void Start(){
		previousPages = new Stack<GameObject>();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Back Pressed");
			goBack ();
		}
			

	}

	// - Cancer funktioner till alla
	// - Ge upp att rigga genom OnClicked GUI
	// - Sepparat för stacken

	// - Alt sätt variabler innan man aktiverar
	// - Typ: gameobject.PreloadParameters() -> gameobject.SetActive(true) - - - > [Onload()] med parametar

	/*
	public enum Page {Profile, AvalibleTasks, ActiveTasks, ....  }
	public void goToPage ( Page page ) {
	switch (page){
	case Page.SpecificTask:
		specificTaskPage.SetActive(true); break;
	case .....
	}

	predefineSpecificTaskId

	}*/

	// ^^^^^^^^^^^^^^


	// !! ! ! ! !! Alt. Kombination av ovan, enum för de lätta rigga genom OnClicked!! !! !! 

	public void goBack(){
		// Stack operations
		if (previousPages.Count != 0) {
			activePage.SetActive (false);
			activePage = previousPages.Pop ();
			activePage.SetActive (true);
		}
	}

	public void goForward(GameObject page){
		previousPages.Push (activePage);
		activePage.SetActive (false);
		activePage = page;
		activePage.SetActive (true);
		// limit size of stack / queue?
	}

// Main View
	// use for windows without dynamic data ( BOT BAR ), can be rigged with ui for buttons.
	public void gotoProfilePage(){
		ProfileView script = profilePage.GetComponent<ProfileView> ();
		profilePage.SetActive (true);
	}

	public void simpleSwap(GameObject page){
		goForward (page);
	}

	public void swapToSpecificTask(Task task){
		//
	}

// PopUp View
	public void popUpOpen(GameObject popUp)
	{
		popUp.SetActive (true);
	}

	public void popUpClose(GameObject popUp)
	{
		popUp.SetActive (false);
	}
}
