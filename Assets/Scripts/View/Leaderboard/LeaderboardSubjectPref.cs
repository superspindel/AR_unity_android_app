using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardSubjectPref : MonoBehaviour {

	private string Title;
	private List<LeaderboardUser> UserList;

	private SimpleObjectPool TitleObjectPool;
	private SimpleObjectPool UserObjectPool;


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
		leaderboardTitle ldbttl = newTitle.GetComponent<leaderboardTitle> ();
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
}
