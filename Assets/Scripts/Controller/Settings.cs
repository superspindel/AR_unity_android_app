using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace Settings{
	public class Settings : MonoBehaviour {

		public int[] SettingsArray = new int[20];


		private string FilePath = UnityEngine.Application.persistentDataPath + "/settings.txt";


		public void SaveFile()
		{
			try
			{
				if(File.Exists(FilePath))
				{
					
				}
			}
			catch(FileNotFoundException) 
			{
				
			}
		}

		public void LoadFile()
		{
			
		}
	}
}
