using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBtnScript : MonoBehaviour {
	private int clickCount;
	private Image SoundBtnImg;
	public Sprite SoundOn, SoundOff;
//	private GameObject btnSound;
	// Use this for initialization
	void Start () {
		clickCount = PlayerPrefs.GetInt ("SoundStatus");
		SoundBtnImg = GetComponent<Image> ();
		//btnSound = Resources.Load ("btnClick") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("SoundStatus") == 0) {
			SoundBtnImg.sprite = SoundOn;

		} else {
			SoundBtnImg.sprite = SoundOff;
		}
	}

	public void onClick()
	{
		clickCount++;


		if (clickCount % 2 == 0) {
			
			PlayerPrefs.SetInt ("SoundStatus", 0);
			//SoundBtnImg.sprite = soundOn;

		} else {
			//soundButtonInst ();
			PlayerPrefs.SetInt ("SoundStatus", 1);
			//SoundBtnImg.sprite = SoundOff;
		}

	}


//	public void soundButtonInst()
//	{
//		if (PlayerPrefs.GetInt ("SoundStatus") == 0) {
//			Instantiate (btnSound);
//		}
//	}
}
