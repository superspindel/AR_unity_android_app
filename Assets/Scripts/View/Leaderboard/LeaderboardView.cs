using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the leaderboard panel, sets up the view of the leaderboards.
public class leaderBoardView : MonoBehaviour {

	public SimpleObjectPool SubjectPool;
	public SimpleObjectPool LeaderboardTitlePool;
	public SimpleObjectPool LeaderboardUserPool;

	public List<Leaderboard> subjectList;

	// TODO: Have setup get information from the cache
	public void Setup()
	{
		foreach (Leaderboard Ldb in subjectList)
		{
			GameObject newSubj = this.SubjectPool.GetObject ();
			newSubj.transform.SetParent (this.transform);
			LeaderboardSubjectPref ldbSubjScript = newSubj.GetComponent<LeaderboardSubjectPref> ();
			ldbSubjScript.Setup (this.LeaderboardTitlePool, this.LeaderboardUserPool, Ldb);
		}
	}
}