using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ldbSubjObj
{
	public titleObject subjectTitle { get; private set; }
	public List<leaderboardUserObject> subjectUserList { get; private set; }

	public ldbSubjObj(titleObject subjectTitle, List<leaderboardUserObject> subjectUserList)
	{
		this.subjectTitle = subjectTitle;
		this.subjectUserList = subjectUserList;
	}
}


public class leaderBoard : MonoBehaviour {

	public SimpleObjectPool subjectPool;
	public SimpleObjectPool leaderboardTitlePool;
	public SimpleObjectPool leaderboardUserPool;

	public List<ldbSubjObj> subjectList;

	public void Setup()
	{
		for (int i = 0; i < subjectList.Count; i++)
		{
			ldbSubjObj ldbSubj = this.subjectList [i];
			GameObject newSubj = this.subjectPool.GetObject ();
			newSubj.transform.SetParent (this.transform);
			LeaderboardSubject ldbSubjScript = newSubj.GetComponent<LeaderboardSubject> ();
			ldbSubjScript.Setup (leaderboardTitlePool, leaderboardUserPool, ldbSubj);
		}
	}

	public void Start()
	{
		Setup ();
	}

}