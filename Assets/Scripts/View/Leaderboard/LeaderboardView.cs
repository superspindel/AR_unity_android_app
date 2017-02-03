using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the leaderboard panel, sets up the view of the leaderboards.
public class leaderBoardView : MonoBehaviour {

	public SimpleObjectPool SubjectPool;
	public SimpleObjectPool LeaderboardTitlePool;
	public SimpleObjectPool LeaderboardUserPool;

	public List<Leaderboard> SubjectList;

	// TODO: Have setup get information from the cache
	public void EnterPage(List<Leaderboard> SubjectList)
	{
		this.SubjectList = SubjectList;
		foreach (Leaderboard Ldb in this.SubjectList)
		{
			GameObject newSubj = this.SubjectPool.GetObject ();
			newSubj.transform.SetParent (this.transform);
			LeaderboardSubjectPref ldbSubjScript = newSubj.GetComponent<LeaderboardSubjectPref> ();
			ldbSubjScript.Setup (this.LeaderboardTitlePool, this.LeaderboardUserPool, Ldb);
		}
	}

	public void LeavePage()
	{
		while (this.transform.childCount > 0)
		{
			GameObject ToRemove = this.transform.GetChild(0).gameObject;
			Prefab Script = ToRemove.GetComponent<Prefab> ();
			Script.ReturnChildren ();
		}
	}

	public void UpdatePage(List<Leaderboard> UpdatedSubjectList)
	{
		this.LeavePage ();
		this.EnterPage (UpdatedSubjectList);
	}
}