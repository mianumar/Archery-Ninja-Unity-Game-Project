using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextBtnScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);


	}


	void TaskOnClick ()
	{
		
//		AdMobManager._AdMobInstance.showInterstitial ();
		SceneManager.LoadScene ((int.Parse (SceneManager.GetActiveScene ().name) + 1).ToString ());
	}



}
