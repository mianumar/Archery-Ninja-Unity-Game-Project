using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WatchVideoBtnScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (OnBtnClick);
	}
	
	// Update is called once per frame
	void OnBtnClick () {
		Adcontrol.instace.ShowRewardedVideo();
		print ("Inside Watch Video");
	}
}
