using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Assets.SimpleAndroidNotifications
{	// Notification class to handle sending of notifications
	// Takes a Notification type and the message to be displayed to the user
	// Will depending on the severity repeat sending of notification until the user has notified the application that it has been read
	public class Notification {

		public string[] Titles = new String[]{"FIRE", "DETONATION", "GAS", "GEAR", "AREA", "LUNCH", "BREAK", "BADGE", "ACHIEVEMENT", "TASK", "SUBTASK"};

		private bool _resend;

		private NotificationParams _parameters;

		private Pageswapper _pageswapper;

		public Notification(NotificationType notiType, string message)
		{
			_pageswapper = GameObject.FindWithTag ("Pageswapper").GetComponent<Pageswapper>();

			if ((int) notiType < 5) // First 5 notification types are alarms, the rest are ordinary notifications
			{
				AlarmParams (Titles [(int) notiType], message); 
			} 
			else 
			{
				NotificationParams (Titles [(int) notiType], message);
			}
			this.Send ();
			CreatePopUp (message, notiType);
		}

		private void CreatePopUp(string message, NotificationType notiType)
		{
			_pageswapper.OpenPopup_General (Titles [(int) notiType], message);

			// Add onClick event to handle user clicking on the PopUp to cancel new notifications being sent.
		}


		// Send will send the notification, and activate the PopUp on screen of the device so that the user can notify application that it has been read.
		public void Send()
		{
			NotificationManager.SendCustom (this._parameters);
		}
		// Creates a Notification params object with the values of a alarm notification
		private void AlarmParams(string title, String message)
		{
			this._parameters = new NotificationParams
			{
				Id = UnityEngine.Random.Range(0, int.MaxValue),
				Delay = TimeSpan.FromSeconds(1),
				Title = title,
				Message = message,
				Ticker = message,
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = NotificationIcon.Event,
				SmallIconColor = new Color(1, 0, 0),
				LargeIcon = "app_icon"
			};
		}
		// Creates a Notification params object with the values of a normal notification
		private void NotificationParams(string title, string message)
		{
			this._parameters = new NotificationParams
			{
				Id = UnityEngine.Random.Range(0, int.MaxValue),
				Delay = TimeSpan.FromSeconds(3),
				Title = title,
				Message = message,
				Ticker = message,
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = NotificationIcon.Message,
				SmallIconColor = new Color(0, 0.29f, 0.6f),
				LargeIcon = "app_icon"
			};
		}
		// Cancels the active notification
		public void CancelNotification()
		{
			NotificationManager.Cancel (this._parameters.Id);
			this._resend = false;
		}
	}
}
