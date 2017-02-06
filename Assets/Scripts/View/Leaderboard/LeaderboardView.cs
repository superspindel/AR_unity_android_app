using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the leaderboard panel, sets up the view of the leaderboards.
public class LeaderBoardView : MonoBehaviour {

	public SimpleObjectPool SubjectPool;
	public SimpleObjectPool LeaderboardTitlePool;
	public SimpleObjectPool LeaderboardUserPool;

	public List<Leaderboard> SubjectList;

	private bool _initialized = false;

	// TODO: Have setup get information from the cache
	public void EnterPage(List<Leaderboard> subjectList)
	{
		this.SubjectList = subjectList;
		foreach (Leaderboard leaderboard in this.SubjectList)
		{
			GameObject SubjectObject = this.SubjectPool.GetObject ();
			SubjectObject.transform.SetParent (this.transform);
			LeaderboardSubjectPref script = SubjectObject.GetComponent<LeaderboardSubjectPref> ();
			script.Setup (this.LeaderboardTitlePool, this.LeaderboardUserPool, leaderboard);
		}
		this._initialized = true;
	}

	public void LeavePage()
	{
		while (this.transform.childCount > 0)
		{
			GameObject toRemove = this.transform.GetChild(0).gameObject;
			Prefab script = toRemove.GetComponent<Prefab> ();
			script.ReturnChildren ();
		}
	}

	public void UpdatePage(List<Leaderboard> updatedSubjectList)
	{
		this.LeavePage ();
		this.EnterPage (updatedSubjectList);
	}
}