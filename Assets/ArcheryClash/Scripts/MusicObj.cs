using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObj : MonoBehaviour {

//	// Use this for initialization
//	public static MusicObj instance;
//
//	void Awake ()
//	{
//		if (instance) {
//			DestroyImmediate (gameObject);
//		} else {
//			DontDestroyOnLoad (gameObject);
//			instance = this;
//		}
//	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("SoundStatus") != 0) {
			GetComponent<AudioSource> ().mute = true;
		} else {
			GetComponent<AudioSource> ().mute = false;
		}
	}
}
