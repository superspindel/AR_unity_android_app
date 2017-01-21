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

		for (int i = 0; i < 4; i++) {
			subTask = (GameObject) Instantiate (subTaskPrefab);
			subTaskList.Add (subTask);
		}

		int c = 0;

		foreach (GameObject g in subTaskList) {
			g.transform.SetParent(transform);
			g.transform.FindChild ("Toggle/Label").GetComponent<Text>().text = "Testar subTasks" + c;
			c++;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
