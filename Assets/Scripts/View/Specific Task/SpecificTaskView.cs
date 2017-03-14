using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpecificTaskView : MonoBehaviour {
	private GameObject _subTaskGroup; // reference to area for spawning subtasks
	private List<GameObject> _subTaskList;
	private SimpleObjectPool _pool;
	[Header("Private Variable Debug")]
	[SerializeField] private int _lastTaskViewed = -1;

	private Text 	_taskTilteText, _taskDescriptionText;
	private Slider 	_regularSlider, _bonusSlider;

	// Use this for initialization
	void Awake () {
		_subTaskGroup 			= transform.FindChild ("Sub Task Group").gameObject; 
		_subTaskList 			= new List<GameObject> ();
		_pool 					= _subTaskGroup.GetComponent<SimpleObjectPool> ();
		_taskTilteText 			= transform.FindChild ("Title").GetComponent<Text> ();
		_taskDescriptionText 	= transform.FindChild ("Description").GetComponent<Text> ();
		_regularSlider 			= transform.FindChild("Title Bar").transform.FindChild("Progress Slider").GetComponent<Slider> ();
		_bonusSlider 			= transform.FindChild("Title Bar").transform.FindChild ("Bonus Slider").GetComponent<Slider> ();
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

		// Create subtasks items
		foreach (SubTask subTask in task.SubTasks) {
			_addSubTask (subTask); 
			// ^ this also updates progress slider
		}
	}

	// LeavePage()
	public void LeavePage(){
		// Clear page
		_clearPage ();

		// Deactivate Page
		this.gameObject.SetActive (false);
	}

	// TODO: setReadOnly, remove toogles etc.
	public void setReadOnly(){

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
	public void RefreshProgress (){
		// counting variables
		float regularTotal, regularCompleted, bonusTotal, bonusCompleted; 
		regularTotal = regularCompleted = bonusTotal = bonusCompleted = 0f;

		// get data [0-100] % TODO: Might need to change to check acutal model when data is persistent on server
		foreach (GameObject g in _subTaskList) {
			SubTaskItem subTask = g.GetComponent<SubTaskItem> ();
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

		// fill sliders TODO: Better handlning if no subtasks of type?
		if (regularTotal == 0) {
			_regularSlider.gameObject.SetActive (false);
		} else {
			_regularSlider.gameObject.SetActive (true);
			_regularSlider.value = (regularCompleted / regularTotal);
		}
		if (bonusTotal == 0) {
			_bonusSlider.gameObject.SetActive (false);
		} else {
			_bonusSlider.gameObject.SetActive (true);
			_bonusSlider.value = (bonusCompleted / bonusTotal);
		}
	}

	private void _addSubTask(SubTask subTask){
		// get prefab from objectpool
		GameObject subTaskGameObject = _pool.GetObject ();

		// attach to subTaskGroup LayoutGroup
		subTaskGameObject.transform.SetParent(_subTaskGroup.transform);

		// Set parameters
		SubTaskItem subTaskItem = subTaskGameObject.GetComponent<SubTaskItem>();
		subTaskItem.SetId (subTask.Id);
		subTaskItem.SetText (subTask.Title + "[" + subTask.Id + "]");
		subTaskItem.SetBonus (subTask.IsBonus);
		subTaskItem.SetStatus (subTask.Status);
		subTaskItem.SetPrechecked (subTask.Status);

		// Set buttons and data (Help should always be avalible)
		subTaskItem.SetAvalibeButtons ((subTask.Warning != null), (subTask.Tools != null), (subTask.Information != null), true);
		if (subTask.Tools != null)
			subTaskItem.Tools = subTask.Tools;
		if (subTask.Warning != null)
			subTaskItem.Warning = subTask.Warning;
		if (subTask.Information != null)
			subTaskItem.Info = subTask.Information;

		// Add to private list for removal later
		_subTaskList.Add (subTaskGameObject);
	}
}
