using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class titleObject
{
	public string title { get; private set; }

}
[System.Serializable]
public class leaderboardUserObject
{
	public int xp { get; private set; }
	public string position { get; private set; }

	public leaderboardUserObject(int xp, string position)
	{
		this.xp = xp;
		this.position = position;
	}
}

public class LeaderboardSubject : MonoBehaviour {

	private titleObject titleObj;
	private List<leaderboardUserObject> userList;

	private SimpleObjectPool titleObjectPool;
	private SimpleObjectPool userObjectPool;


	public void Setup(SimpleObjectPool titleObjectPool, SimpleObjectPool userObjectPool, ldbSubjObj ldbSubObj)
	{
		this.titleObjectPool = titleObjectPool;
		this.userObjectPool = userObjectPool;
		this.titleObj = ldbSubObj.subjectTitle;
		this.userList = ldbSubObj.subjectUserList;

		this.createTitle ();
		this.insertLeaderboardUsers ();
	}

	private void createTitle()
	{
		GameObject newTitle = this.titleObjectPool.GetObject ();
		newTitle.transform.SetParent (this.transform);
		leaderboardTitle ldbttl = newTitle.GetComponent<leaderboardTitle> ();
		ldbttl.Setup (titleObj.title);
	}

	private void insertLeaderboardUsers()
	{
		for (int i = 0; i < userList.Count; i++)
		{
			leaderboardUserObject ldbUsObj = this.userList [i];
			GameObject newUsObj = this.userObjectPool.GetObject ();
			newUsObj.transform.SetParent (this.transform);
			LeaderBoardUser ldbUser = newUsObj.GetComponent<LeaderBoardUser> ();
			ldbUser.Setup (ldbUsObj, i == userList.Count-1);
		}
	}
}
