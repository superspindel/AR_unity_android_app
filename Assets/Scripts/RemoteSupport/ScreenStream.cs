using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model;
using UnityEngine;



public class ScreenStream : MonoBehaviour
{

    public bool PublishStream;

    private readonly ImageStream _stream = new ImageStream { Id = "stream1" };


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    

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

    void OnGUI()
    {
        if (!CommunicationsApi.IsAvailable || !takePhoto)
            return;

        takePhoto = false;
        try
        {
            string d = Convert.ToBase64String(FetchScreen());
            _stream.Image = d;
            DataStore.Update(_stream, null);
        }
        catch (Exception)
        {
            
        }
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
