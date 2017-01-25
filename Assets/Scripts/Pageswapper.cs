using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pageswapper : MonoBehaviour {

	public GameObject profilePage;
	public GameObject SpecificTaskPage;
	public GameObject availableTaskPage;
	public GameObject activePage;

	public void gotoPage( GameObject newPage )
	{
		leavePage ();
		newPage.SetActive (true);
		activePage = newPage;
	}
	public void leavePage()
	{
		activePage.SetActive (false);
	}

	public void popUpOpen(GameObject popUp)
	{
		popUp.SetActive (true);
	}

	public void popUpClose(GameObject popUp)
	{
		popUp.SetActive (false);
	}
}
