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
		foreach (Leaderboard ldb in this.SubjectList)
		{
			// TODO: Check Ldb.Available
			if (!this._initialized) 
			{
				ldb.Updated += obj => {
					this.UpdatePage(subjectList);
				};
			}
			GameObject newSubj = this.SubjectPool.GetObject ();
			newSubj.transform.SetParent (this.transform);
			LeaderboardSubjectPref ldbSubjScript = newSubj.GetComponent<LeaderboardSubjectPref> ();
			ldbSubjScript.Setup (this.LeaderboardTitlePool, this.LeaderboardUserPool, ldb);
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