using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the leaderboard panel, sets up the view of the leaderboards.
public class LeaderboardView : MonoBehaviour {

	private SimpleObjectPool SubjectPool;
	private SimpleObjectPool LeaderboardTitlePool;
	private SimpleObjectPool LeaderboardUserPool;

	private Transform Group;

	private List<Leaderboard> SubjectList;


	// TODO: Have setup get information from the cache
	public void EnterPage(List<Leaderboard> subjectList)
	{
		this.gameObject.SetActive (true);
		foreach (Leaderboard leaderboard in subjectList)
		{
			this.SubjectList = subjectList;
			if (leaderboard.Available) 
			{
				GameObject SubjectObject = this.SubjectPool.GetObject ();
				SubjectObject.transform.SetParent (this.Group);
				LeaderboardSubjectPref script = SubjectObject.GetComponent<LeaderboardSubjectPref> ();
				script.Setup (this.LeaderboardTitlePool, this.LeaderboardUserPool, leaderboard);
			}
		}
	}

	void Awake()
	{
		this.Group = transform.FindChild ("Group").gameObject.transform;
		this.SubjectPool = transform.FindChild ("SubjectPool").GetComponent<SimpleObjectPool> ();
		this.LeaderboardTitlePool = transform.FindChild ("leaderboardTitlePool").GetComponent<SimpleObjectPool> ();
		this.LeaderboardUserPool = transform.FindChild ("leaderboardUserPool").GetComponent<SimpleObjectPool> ();
	}

	public void LeavePage()
	{
		while (this.Group.childCount > 0)
		{
			GameObject toRemove = this.Group.GetChild(0).gameObject;
			Prefab script = toRemove.GetComponent<Prefab> ();
			script.ReturnChildren ();
			SubjectPool.ReturnObject (toRemove);
		}
		this.gameObject.SetActive (false);
	}

	public void UpdatePage(List<Leaderboard> updatedSubjectList)
	{
		this.LeavePage ();
		this.EnterPage (this.SubjectList);
	}

}