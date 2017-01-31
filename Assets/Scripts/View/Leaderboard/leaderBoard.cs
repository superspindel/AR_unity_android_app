using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ldbSubjObj
{
	public titleObject subjectTitle;
	public List<leaderboardUserObject> subjectUserList;

	public ldbSubjObj(titleObject subjectTitle, List<leaderboardUserObject> subjectUserList)
	{
		this.subjectTitle = subjectTitle;
		this.subjectUserList = subjectUserList;
	}

	public titleObject getTitle()
	{
		return this.subjectTitle;
	}

	public List<leaderboardUserObject> getUserList()
	{
		return this.subjectUserList;
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
			ldbSubjObj ldbSubj = subjectList [i];
			GameObject newSubj = subjectPool.GetObject ();
			newSubj.transform.SetParent (this.transform);
			LeaderboardSubject ldbSubjScript = newSubj.GetComponent<LeaderboardSubject> ();
			ldbSubjScript.Setup (leaderboardTitlePool, leaderboardUserPool, ldbSubj.getTitle(), ldbSubj.getUserList());
		}
	}

	public void Start()
	{
		Setup ();
	}

}
