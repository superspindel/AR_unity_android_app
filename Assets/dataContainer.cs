using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataContainer : MonoBehaviour {

	//TEST VARIABLES
	[Header("Testing Variables")]
	[Tooltip("Use for testing")]
	public int test_nrOfSubTasks;


	[Header("Real Variables")]
	// List of "My Tasks / Active Tasks" TaskData wich contains a list SubTaskData
	public List<TaskData> activeTasks;
	// List of "Avalible Tasks" TaskData wich contains a list SubTaskData
	public List<TaskData> avalibleTasks;

	public List<AchievementObject> achievementList;
	public List<BadgeObject> badgeList;
	public Profile activeProfile;

	public ArrayList settingsArray;

	void Awake(){
		Debug.Log ("DataContainer is Awake");
		activeTasks = new List<TaskData> ();
		createTestTaskList ();
		Debug.Log ("Test Task List Created");
	}

	public List<AchievementObject> getAchievementList()
	{
		return this.achievementList;
	}

	public List<BadgeObject> getBadgeList()
	{
		return this.badgeList;
	}

	public void addAchievement(AchievementObject achObj)
	{
		this.achievementList.Add (achObj);
	}

	public void setAchievementList(List<AchievementObject> newList)
	{
		this.achievementList = newList;
	}

	public void removeAchievement(AchievementObject achObj)
	{
		this.achievementList.Remove (achObj);
	}

	public void addBadge(BadgeObject bdgObj)
	{
		this.badgeList.Add (bdgObj);
	}

	public void setBadgeList(List<BadgeObject> newList)
	{
		this.badgeList = newList;
	}

	public void removeBadge(BadgeObject bdgObj)
	{
		this.badgeList.Remove (bdgObj);
	}

	public Profile getProfile()
	{
		return activeProfile;
	}

	public void setProfile(Profile newProfile)
	{
		this.activeProfile = newProfile;
	}


	// Tasks & SubTasks TODO: Separate active / avalible or use same list with flag?
	public TaskData getTaskDataById(int id){
		foreach (TaskData t in activeTasks) {
			if (t.id == id)
				return t;
		}
		foreach (TaskData t in avalibleTasks) {
			if (t.id == id)
				return t;
		}
		return null;
	}

	private int testTaskCount = 0;

	public void createTestTaskList(){
		// Create TaskData
		TaskData testTask = new TaskData();
		testTask.id 			= testTaskCount++;
		testTask.title 			= "TestTask 1";
		testTask.description 	= "Description of TestTask 1";
		testTask.totalxp 		= 1337;
		testTask.location		= new Vector3(0f,0f,0f);
		testTask.status			= Status.InProgress;
		testTask.tools			= new List<Tool>(); 
		testTask.subTasks		= new List<SubTaskData>(); 

		// Create SubTaskData
		for (int i = 0; i < test_nrOfSubTasks; i++) {
			SubTaskData testSubTask = new SubTaskData ();
			testSubTask.id 			= i;
			testSubTask.title 		= "SubTask[" + i + "]";
			testSubTask.information = "information for subtask nr " + i;
			testSubTask.warning 	= "Warning";
			testSubTask.tools		= new List<Tool>(); 
			testSubTask.tools.Add(new Tool("helm"));
			testSubTask.status		= Status.InProgress;
			testSubTask.isBonus		= (Random.value > 0.5); // true or false

			testTask.subTasks.Add (testSubTask);
		}

		// Add to activeTasks
		this.activeTasks.Add (testTask);
	}
}
