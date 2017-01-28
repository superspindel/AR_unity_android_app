using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpecificTaskView : MonoBehaviour {
	[Header("Testing Variables")]
	[Tooltip("Use for testing")]
	public int testListSize;

	[Header("UI Gameobjects")]
	public GameObject subTaskGroup;

	[Header("Private Variable Debug")]
	[SerializeField] private List<GameObject> subTaskList;
	[SerializeField] private SimpleObjectPool pool;
	[SerializeField] private float regular;
	[SerializeField] private float bonus;


	// Use this for initialization
	void Start () {
		// Init List for reference and Pool for getting the prefabs.
		subTaskList = new List<GameObject> ();
		pool = subTaskGroup.GetComponent<SimpleObjectPool> ();

		// Test
		generateTestList();
		refresh ();
	}

	// When opened from bottom bar
	void enterPage(){
		//subTaskList = getSubTasksFromTasks (task);

	}

	public void refresh(){
		refreshProgress ();
	}

	// refreshes sliders
	void refreshProgress (){
		float r_t = 0f; // regular total
		float r_c = 0f; // regular completed
		float b_t = 0f; // bonus total
		float b_c = 0f; // bonus completed
		foreach (GameObject g in subTaskList) {
			SubTask subTask = g.GetComponent<SubTask> ();
			if (!subTask.isBonus) {
				if (subTask.status == Status.Completed) {
					r_c++;
				}
				r_t++;
			} else {
				if (subTask.status == Status.Completed) {
					b_c++;
				}
				b_t++;
			}

		}
		regular = (r_c / r_t);
		bonus = (b_c / b_t);

		GameObject.Find ("Progress Slider").GetComponent<Slider> ().value = regular;
		GameObject.Find ("Bonus Slider").GetComponent<Slider> ().value = bonus;
	}

	void addSubTask(int id, string name, bool isBonus, bool tool, bool help, bool info, bool warning){
		// get prefab from objectpool
		GameObject g = pool.GetObject ();
		// attach to subTaskGroup LayoutGroup
		g.transform.SetParent(subTaskGroup.transform);
		// Set parameters
		SubTask st = g.GetComponent<SubTask>();
		g.GetComponent<SubTask>().setText (name + "[" + id + "]");
		g.GetComponent<SubTask>().setBonus (isBonus);
		g.GetComponent<SubTask>().setAvalibeButtons (tool, help, info, warning);
		g.GetComponent<SubTask> ().setStatus (Status.InProgress);

		subTaskList.Add (g);
	}


	// Used for testing
	void generateTestList(){
		for (int i = 0; i < testListSize; i++) {
			addSubTask (i, "SubTask",  r(), r(), r(), r(), r());
		}
	}

	private bool r(){
		return(Random.value > 0.5);
	}

}
