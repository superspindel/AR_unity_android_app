using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpecificTaskView : MonoBehaviour {
	[Header("Testing Variables")]
	[Tooltip("Use for testing")]
	public bool UseGeneratedTestList;
	public int TestListSize;

	[Header("UI Gameobjects")]
	public GameObject SubTaskGroup;

	[Header("Private Variable Debug")]
	[SerializeField] private List<GameObject> _subTaskList;
	[SerializeField] private SimpleObjectPool _pool;
	[SerializeField] private float _regular;
	[SerializeField] private float _bonus;
	[SerializeField] private int _lastTaskViewed = -1;


	// Use this for initialization (WHEN FIRST ENABLED)
	void Start () {
		// Init List for reference and _pool for getting the prefabs.
		_subTaskList = new List<GameObject> ();
		_pool = SubTaskGroup.GetComponent<SimpleObjectPool> ();

		// Test
		if (UseGeneratedTestList) {
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
		if (taskId != _lastTaskViewed) {
			// if not first time return subtasks to pool
			if (_lastTaskViewed != -1) {
				foreach (Transform child in transform) {
					_pool.ReturnObject (child.gameObject);
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
		_lastTaskViewed = taskId;
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
		foreach (GameObject g in _subTaskList) {
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
		_regular = (r_c / r_t);
		_bonus = (b_c / b_t);

		GameObject.Find ("Progress Slider").GetComponent<Slider> ().value = _regular;
		GameObject.Find ("_bonus Slider").GetComponent<Slider> ().value = _bonus;
	}

	void addSubTask(int id, string name, bool isBonus, List<Tool> tools, string info, string warning){
		// get prefab from objectpool
		GameObject g = _pool.GetObject ();
		// attach to subTaskGroup LayoutGroup
		g.transform.SetParent(SubTaskGroup.transform);
		// Set parameters
		SubTaskItem st = g.GetComponent<SubTaskItem>();
		st.setText (name + "[" + id + "]");
		st.setBonus (isBonus);
		st.setStatus (Status.InProgress);

		// Set buttons and data (Help should always be avalible)
		g.GetComponent<SubTaskItem>().setAvalibeButtons ((warning != null), (tools != null), (info != null), true);
		if (tools != null)
			st.Tools = tools;
		if (warning != null)
			st.Warning = warning;
		if (info != null)
			st.Info = info;

		_subTaskList.Add (g);
	}


	// Used for testing
	void generateTestList(){
		for (int i = 0; i < TestListSize; i++) {
			addSubTask (i++, "SubTask",  r(), null, null, null);
		}
	}

	private bool r(){
		return(Random.value > 0.5);
	}

}
