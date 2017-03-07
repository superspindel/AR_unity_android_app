using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AugmentedRealityView : MonoBehaviour {

	private string ARName = "AugmentedReality";
	private string MenuName = "_Main";

	// Load scene
	public void enterPage()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (ARName);
	}

	// Exit scene
	public void leavePage()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (MenuName);
	}
}
