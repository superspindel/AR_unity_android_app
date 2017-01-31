using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpecificTaskView : MonoBehaviour {
	[Header("Testing Variables")]
	[Tooltip("Use for testing")]
	public bool useGeneratedTestList;
	public int testListSize;

	[Header("UI Gameobjects")]
	public GameObject subTaskGroup;

	[Header("Private Variable Debug")]
	[SerializeField] private List<GameObject> subTaskList;
	[SerializeField] private SimpleObjectPool pool;
	[SerializeField] private float regular;
	[SerializeField] private float bonus;
	[SerializeField] private int lastTaskViewed = -1;


	// Use this for initialization (WHEN FIRST ENABLED)
	void Start () {
		// Init List for reference and Pool for getting the prefabs.
		subTaskList = new List<GameObject> ();
		pool = subTaskGroup.GetComponent<SimpleObjectPool> ();

		// Test
		if (useGeneratedTestList) {
			generateTestList ();
		} else {
			// get data from datacontainer
			enterPage (0);
		}
		refresh ();
	}

	// When opened
	void enterPage(int taskId){

		// if not the same page, rebuild page
		if (taskId != lastTaskViewed) {
			// if not first time return subtasks to pool
			if (lastTaskViewed != -1) {
				foreach (Transform child in transform) {
					pool.ReturnObject (child.gameObject);
				}
			}

			// get data from dataContainer
			DataContainer data = GameObject.Find ("DataContainer").GetComponent<DataContainer> ();
			Task taskData = data.activeTasks[0];

			// Set Task Variables
			transform.FindChild ("Title").GetComponent<Text> ().text = taskData.Title;
			transform.FindChild ("Description").GetComponent<Text> ().text = taskData.Description;

			// Set subtasks
			int i = 0;
			foreach (SubTask subTaskData in taskData.SubTasks) {
				addSubTask (i++, subTaskData.Title, subTaskData.IsBonus, subTaskData.Tools, subTaskData.Information, subTaskData.Warning);
			}
		}

		// no need to rebuild, just enable do nothing
		this.gameObject.SetActive(true);
		lastTaskViewed = taskId;
	}

	// When leaving page
	void leavePage(){
		this.gameObject.SetActive (false);
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
			if (!subTask.IsBonus) {
				if (subTask.Status == Status.Completed) {
					r_c++;
				}
				r_t++;
			} else {
				if (subTask.Status == Status.Completed) {
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

	void addSubTask(int id, string name, bool isBonus, List<Tool> tools, string info, string warning){
		// get prefab from objectpool
		GameObject g = pool.GetObject ();
		// attach to subTaskGroup LayoutGroup
		g.transform.SetParent(subTaskGroup.transform);
		// Set parameters
		SubTaskItem st = g.GetComponent<SubTaskItem>();
		st.setText (name + "[" + id + "]");
		st.setBonus (isBonus);
		st.setStatus (Status.InProgress);

		// Set buttons and data (Help should always be avalible)
		g.GetComponent<SubTaskItem>().setAvalibeButtons ((warning != null), (tools != null), (info != null), true);
		if (tools != null)
			st.tools = tools;
		if (warning != null)
			st.warning = warning;
		if (info != null)
			st.info = info;

		subTaskList.Add (g);
	}


	// Used for testing
	void generateTestList(){
		for (int i = 0; i < testListSize; i++) {
			addSubTask (i++, "SubTask",  r(), null, null, null);
		}
	}

	private bool r(){
		return(Random.value > 0.5);
	}

}
