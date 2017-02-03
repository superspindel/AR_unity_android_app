using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Assets.SimpleAndroidNotifications
{	// Notification class to handle sending of notifications
	// Takes a Notification type and the message to be displayed to the user
	// Will depending on the severity repeat sending of notification until the user has notified the application that it has been read
	public class Notification : MonoBehaviour {

		public string[] Titles = new String[]{"FIRE", "DETONATION", "GAS", "GEAR", "AREA", "LUNCH", "BREAK", "BADGE", "ACHIEVEMENT", "TASK", "SUBTASK"};
		public SimpleObjectPool PopUpPool;
		public Transform Content;

		private bool _resend;

		private NotificationParams _Parameters;

		public Notification(NotificationType NotiType, string Message)
		{
			if ((int) NotiType < 5) // First 5 notification types are alarms, the rest are ordinary notifications
			{
				AlarmParams (Titles [(int) NotiType], Message); 
			} 
			else 
			{
				NotificationParams (Titles [(int) NotiType], Message);
			}
		}

		private void CreatePopUp(string Message, string Title, NotificationType NotiType)
		{
			GameObject NewPopUpObject = this.PopUpPool.GetObject ();
			NewPopUpObject.transform.SetParent (this.Content);
			PopUp PopUpScript = NewPopUpObject.GetComponent<PopUp> ();
			PopUpScript.enterPopup ();
			PopUpScript.setPanelTitle (NotiType.ToString ());
			PopUpScript.setContentTitle (Title);
			PopUpScript.setContentText (Message);
			// Add onClick event to handle user clicking on the PopUp to cancel new notifications being sent.
		}

		void Update()
		{
			if (_resend) 
			{
				NotificationManager.Cancel (this._Parameters.Id);
				this.Send ();
			}
		}
		// Send will send the notification, and activate the PopUp on screen of the device so that the user can notify application that it has been read.
		public void Send()
		{
			NotificationManager.SendCustom (this._Parameters);
		}
		// Creates a Notification params object with the values of a alarm notification
		private void AlarmParams(string Title, String Message)
		{
			this._Parameters = new NotificationParams
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
		// Creates a Notification params object with the values of a normal notification
		private void NotificationParams(string Title, string Message)
		{
			this._Parameters = new NotificationParams
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
		// Cancels the active notification
		public void CancelNotification()
		{
			NotificationManager.Cancel (this._Parameters.Id);
			this._resend = false;
		}
	}
}
