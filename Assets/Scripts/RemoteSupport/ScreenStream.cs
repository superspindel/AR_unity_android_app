﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;



public class ScreenStream : MonoBehaviour
{

    public bool PublishStream;

    private readonly RemoteSupportStream _stream = new RemoteSupportStream { Id = "stream1" };
    public RemoteSupportMouse RemoteMouse { get; set; }


	// Use this for initialization
	void Start () {
	}

    private bool _netSetup = false;
	// Update is called once per frame
	void Update ()
	{
	    if (!_netSetup && CommunicationsApi.IsAvailable)
	    {
	        _netSetup = true;
            DataStore.RegisterAutoUpdate<RemoteSupportMouse>();
            DataStore.Get<RemoteSupportMouse>("mouse1", x =>
            {
					this.RemoteMouse = x;
            });
        }

    }

    void LateUpdate()
    {
        
    }

    private bool takePhoto = false;

    void FixedUpdate()
    {
        if (_stream.Streaming != PublishStream)
        {
            _stream.Streaming = PublishStream;
            DataStore.Update(_stream, null);
        }
        if(PublishStream)
            takePhoto = true;
    }

    void OnPostRender()
    {
        Debug.Log("render");
    }
	int frame = 0;
    void OnGUI()
    {
		if (frame > 80) {
			if (!CommunicationsApi.IsAvailable || !takePhoto)
				return;
			new WaitForEndOfFrame ();
			takePhoto = false;
			try {
				string d = Convert.ToBase64String (FetchScreen ());
				_stream.Image = d;
				DataStore.Update (_stream, null);
			} catch (Exception) {
	        
			}
			frame = 0;
		} else
			frame++;
    }
    
    byte[] FetchScreen()
    {
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] bytes = tex.EncodeToPNG();
		Destroy(tex);

        return bytes;
    }
}
