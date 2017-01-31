using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class titleObject
{
	public string title;

	public string getTitle()
	{
		return this.title;
	}

	public void setTitle(string title)
	{
		this.title = title;
	}
}
[System.Serializable]
public class leaderboardUserObject
{
	public int xp;
	public string position;

	public leaderboardUserObject(int xp, string position)
	{
		this.xp = xp;
		this.position = position;
	}

	public int getXp()
	{
		return this.xp;
	}

	public void setXp(int xp)
	{
		this.xp = xp;
	}

	public string getPosition()
	{
		return this.position;
	}


	public void setPosition(string position)
	{
		this.position = position;
	}
}

public class LeaderboardSubject : MonoBehaviour {

	private titleObject title;
	private List<leaderboardUserObject> userList;

	private SimpleObjectPool titleObjectPool;
	private SimpleObjectPool userObjectPool;


	public void Setup(SimpleObjectPool titleObjectPool, SimpleObjectPool userObjectPool, titleObject title, List<leaderboardUserObject> userList)
	{
		this.titleObjectPool = titleObjectPool;
		this.userObjectPool = userObjectPool;
		this.title = title;
		this.userList = userList;

		createTitle ();
		insertLeaderboardUsers ();
	}

	private void createTitle()
	{
		GameObject newTitle = titleObjectPool.GetObject ();
		newTitle.transform.SetParent (this.transform);
		leaderboardTitle ldbttl = newTitle.GetComponent<leaderboardTitle> ();
		ldbttl.Setup (title.getTitle());
	}

	private void insertLeaderboardUsers()
	{
		for (int i = 0; i < userList.Count; i++)
		{
			leaderboardUserObject ldbUsObj = userList [i];
			GameObject newUsObj = userObjectPool.GetObject ();
			newUsObj.transform.SetParent (this.transform);
			LeaderBoardUser ldbUser = newUsObj.GetComponent<LeaderBoardUser> ();
			ldbUser.Setup (ldbUsObj, i == userList.Count-1);
		}
	}
}
