using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpecificTaskView : MonoBehaviour {
	[Header("UI Gameobjects")]
	public GameObject SubTaskGroup;

	[Header("Private Variable Debug")]
	[SerializeField] private List<GameObject> _subTaskList;
	[SerializeField] private SimpleObjectPool _pool;
	[SerializeField] private int _lastTaskViewed = -1;

	private Text 	_taskTilteText, _taskDescriptionText;
	private Slider 	_regularSlider, _bonusSlider;

	// Use this for initialization
	void Awake () {
		_subTaskList = new List<GameObject> ();
		_pool = SubTaskGroup.GetComponent<SimpleObjectPool> ();
		_taskTilteText = transform.FindChild ("Title").GetComponent<Text> ();
		_taskDescriptionText = transform.FindChild ("Description").GetComponent<Text> ();
	}

	// EnterPage with Task (Controller gets task via ID from API)
	public void EnterPage(Task task){
		// Activate gameObject
		this.gameObject.SetActive (true);

		// render page
		UpdatePage (task);
		_lastTaskViewed = int.Parse(task.Id);
	}

	// UpdatePage()
	public void UpdatePage(Task task){
		// Clear page info
		_clearPage ();

		// Set Task Text Fields
		_taskTilteText.text = task.Title;
		_taskDescriptionText.text = task.Description;

		// Update Progress Sliders
		_refreshProgress();

		// Create subtasks items
		foreach (SubTask subTask in task.SubTasks) {
			_addSubTask (subTask);
		}
	}

	// LeavePage()
	public void LeavePage(){
		// Clear page
		_clearPage ();

		// Deactivate Page
		this.gameObject.SetActive (false);
	}

	private void _clearPage(){
		_taskTilteText.text = "";
		_taskDescriptionText.text = "";

		// Return Subtask Items To Pool
		foreach (GameObject subTaskItem in _subTaskList) {
			_pool.ReturnObject (subTaskItem);
		}
	}

	// refreshes sliders
	private void _refreshProgress (){
		// counting variables
		float regularTotal, regularCompleted, bonusTotal, bonusCompleted; 
		regularTotal = regularCompleted = bonusTotal = bonusCompleted = 0f;

		// get data [0-100] %
		foreach (GameObject g in _subTaskList) {
			SubTask subTask = g.GetComponent<SubTask> ();
			if (!subTask.IsBonus) {
				if (subTask.Status == Status.Completed)
					regularCompleted++;
				regularTotal++;
			} else {
				if (subTask.Status == Status.Completed)
					bonusCompleted++;
				bonusTotal++;
			}
		}

		// fill sliders
		_regularSlider.value 	= (regularCompleted / regularTotal);
		_bonusSlider.value  	= (bonusCompleted / bonusTotal);
	}

	private void _addSubTask(SubTask subTask){
		// get prefab from objectpool
		GameObject subTaskGameObject = _pool.GetObject ();

		// attach to subTaskGroup LayoutGroup
		subTaskGameObject.transform.SetParent(SubTaskGroup.transform);

		// Set parameters
		SubTaskItem subTaskItem = subTaskGameObject.GetComponent<SubTaskItem>();
		subTaskItem.SetId (subTask.Id);
		subTaskItem.SetText (subTask.Title + "[" + subTask.Id + "]");
		subTaskItem.SetBonus (subTask.IsBonus);
		subTaskItem.SetStatus (subTask.Status);

		// Set buttons and data (Help should always be avalible)
		subTaskItem.SetAvalibeButtons ((subTask.Warning != null), (subTask.Tools != null), (subTask.Information != null), true);
		if (subTask.Tools != null)
			subTaskItem.Tools = subTaskItem.Tools;
		if (subTask.Warning != null)
			subTaskItem.Warning = subTask.Warning;
		if (subTask.Information != null)
			subTaskItem.Info = subTask.Information;

		// Add to private list for removal later
		_subTaskList.Add (subTaskGameObject);
	}
}
