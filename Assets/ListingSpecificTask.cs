using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // For changing <Text>

public class ListingSpecificTask : MonoBehaviour {

	public GameObject subTaskPrefab;
	GameObject subTask;

	private List<GameObject> subTaskList;

	// Use this for initialization
	void Start () {
		subTaskList = new List<GameObject> ();

		for (int i = 0; i < 20; i++) {
			subTask = (GameObject) Instantiate (subTaskPrefab);
			subTaskList.Add (subTask);
		}

		int c = 0;

		foreach (GameObject g in subTaskList) {
			g.transform.SetParent(transform);
			g.transform.FindChild ("Name").GetComponent<Text>().text = "Sub Task [" + c + "]";
			c++;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
