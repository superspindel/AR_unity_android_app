using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Assets.SimpleAndroidNotifications
{
	public class Notification : MonoBehaviour {

		public string[] Titles = new String[]{"FIRE", "DETONATION", "GAS", "GEAR", "AREA", "LUNCH", "BREAK", "BADGE", "ACHIEVEMENT", "TASK", "SUBTASK"};

		public NotificationParams Parameters;
		/// <summary>
		/// Use "" for simple notification. Use "app_icon" to use the app icon. Use custom value but first place image to "simple-android-notifications.aar/res/". To modify "aar" file just rename it to "zip" and back.
		/// </summary>
		public string LargeIcon;

		public Notification(NotificationType NotiType, string Message)
		{
			if ((int) NotiType < 5) 
			{
				AlarmParams (Titles [(int) NotiType], Message);
			} 
			else 
			{
				NotificationParams (Titles [(int) NotiType], Message);
			}
		}

		private void AlarmParams(string Title, String Message)
		{
			this.Parameters = new NotificationParams
			{
				Id = UnityEngine.Random.Range(0, int.MaxValue),
				Delay = TimeSpan.FromSeconds(1),
				Title = Title,
				Message = Message,
				Ticker = Message,
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = NotificationIcon.Warning,
				SmallIconColor = new Color(1, 0, 0),
				LargeIcon = "app_icon"
			};
		}

		private void NotificationParams(string Title, string Message)
		{
			this.Parameters = new NotificationParams
			{
				Id = UnityEngine.Random.Range(0, int.MaxValue),
				Delay = TimeSpan.FromSeconds(3),
				Title = Title,
				Message = Message,
				Ticker = Message,
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = NotificationIcon.Message,
				SmallIconColor = new Color(0, 0.29f, 0.6f),
				LargeIcon = "app_icon"
			};
		}

		public void CancelNotification()
		{
			NotificationManager.Cancel (this.Parameters.Id);
		}
	}
}
