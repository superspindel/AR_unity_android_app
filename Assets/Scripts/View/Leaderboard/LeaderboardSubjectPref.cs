using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardSubjectPref : Prefab {

	private string Title;
	private List<LeaderboardUser> UserList;

	private SimpleObjectPool TitleObjectPool;
	private SimpleObjectPool UserObjectPool;

	// Creates the subject gameobject and sets the title and adds the users in the leaderboard.
	public void Setup(SimpleObjectPool TitleObjectPool, SimpleObjectPool UserObjectPool, Leaderboard ldbSubObj)
	{
		this.TitleObjectPool = TitleObjectPool;
		this.UserObjectPool = UserObjectPool;
		this.Title = ldbSubObj.Title;
		this.UserList = ldbSubObj.LeaderboardUsers;

		this.createTitle ();
		this.insertLeaderboardUsers ();
	}

	private void createTitle()
	{
		GameObject newTitle = this.TitleObjectPool.GetObject ();
		newTitle.transform.SetParent (this.transform);
		leaderboardTitlePref ldbttl = newTitle.GetComponent<leaderboardTitlePref> ();
		ldbttl.Setup (this.Title);
	}

	private void insertLeaderboardUsers()
	{
		int i = 0;
		foreach (LeaderboardUser user in UserList)
		{
			GameObject newUsObj = this.UserObjectPool.GetObject ();
			newUsObj.transform.SetParent (this.transform);
			LeaderboardUserPref ldbUser = newUsObj.GetComponent<LeaderboardUserPref> ();
			ldbUser.Setup (user, i == UserList.Count-1);
			i++;
		}
	}

	public override void ReturnChildren()
	{
		while (this.transform.childCount > 0)
		{
			GameObject toRemove = this.transform.GetChild(0).gameObject;
			PooledObject script = toRemove.GetComponent<PooledObject> ();
			if (script.pool == this.TitleObjectPool) 
			{
				this.TitleObjectPool.ReturnObject (toRemove);
			} 
			else 
			{
				this.UserObjectPool.ReturnObject (toRemove);
			}
		}
	}
}
