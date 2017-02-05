using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class AppSettings {
	public string ImagePath { get; set; }
	public bool Help { get; set; }
	public bool Remote { get; set; }
	public bool Account { get; set; }
	public int UserID{ get; set; }
	public int AchievementTracker { get; set; }
	public int BadgeTracker { get; set; }

}
public class Settings : MonoBehaviour {


	private static AppSettings _settings { get; set;}
	public static AppSettings application { get {if (_settings == null) {LoadFile ();} return _settings;}}


	public static string FilePath = UnityEngine.Application.persistentDataPath + "/settings.txt";

	public static void SaveFile()
	{
		_settings.Account = false;
		try
		{
			File.WriteAllText(FilePath, SimpleJson.SimpleJson.SerializeObject(_settings));
		}
		catch(FileNotFoundException e) 
		{
			File.Create (FilePath);
			File.WriteAllText(FilePath, SimpleJson.SimpleJson.SerializeObject(_settings));
		}

	}

	public static void LoadFile()
	{
		try
		{
			_settings = SimpleJson.SimpleJson.DeserializeObject<AppSettings>(File.ReadAllText(FilePath));

		}
		catch(Exception e)
		{
			_settings = new AppSettings ();
			_settings.Account = true;
			_settings.UserID = 0;
			_settings.ImagePath = "";
			_settings.Help = true;
			_settings.Remote = true;
			_settings.AchievementTracker = 0;
			_settings.BadgeTracker = 0;
		}
	}
}
