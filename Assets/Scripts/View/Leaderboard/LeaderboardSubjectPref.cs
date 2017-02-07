using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardSubjectPref : Prefab {

	private string _title;
	private List<LeaderboardUser> _userList;

	private SimpleObjectPool _titleObjectPool;
	private SimpleObjectPool _userObjectPool;


	// Creates the subject gameobject and sets the title and adds the users in the leaderboard.
	public void Setup(SimpleObjectPool titleObjectPool, SimpleObjectPool userObjectPool, Leaderboard ldbSubObj)
	{
		this._titleObjectPool = titleObjectPool;
		this._userObjectPool = userObjectPool;
		this._title = ldbSubObj.Title;
		this._userList = ldbSubObj.LeaderboardUsers;

		this.CreateTitle ();
		this.InsertLeaderboardUsers ();
	}

	private void CreateTitle()
	{
		GameObject newTitle = this._titleObjectPool.GetObject ();
		newTitle.transform.SetParent (this.transform);
		LeaderboardTitlePref ldbttl = newTitle.GetComponent<LeaderboardTitlePref> ();
		ldbttl.Setup (this._title);
	}

	private void InsertLeaderboardUsers()
	{
		int i = 0;
		foreach (LeaderboardUser user in _userList)
		{
			GameObject newUsObj = this._userObjectPool.GetObject ();
			newUsObj.transform.SetParent (this.transform);
			LeaderboardUserPref ldbUser = newUsObj.GetComponent<LeaderboardUserPref> ();
			ldbUser.Setup (user, i == _userList.Count-1);
			i++;
		}
	}

	public override void ReturnChildren()
	{
		while (this.transform.childCount > 0)
		{
			GameObject toRemove = this.transform.GetChild(0).gameObject;
			PooledObject script = toRemove.GetComponent<PooledObject> ();
			if (script.Pool == this._titleObjectPool) 
			{
				this._titleObjectPool.ReturnObject (toRemove);
			} 
			else 
			{
				this._userObjectPool.ReturnObject (toRemove);
			}
		}
	}
	public void UpdateSubject()
	{
		this.ReturnChildren ();
		this.InsertLeaderboardUsers ();
	}
}
