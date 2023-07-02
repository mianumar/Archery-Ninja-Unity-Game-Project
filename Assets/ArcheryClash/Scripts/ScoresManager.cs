using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoresManager : MonoBehaviour
{

	public static bool isCompleted, isFailed, isGameOver, isHumanHit, isPaused;
	public Text NoOfMoves, AvlblTxt;
	public GameObject compBox, failBox, boxBg, pauseBox;
	private Animator compAnim, failAnim, pauseAnim;
	public GameObject failSound, winSound;
	private int wonCoins;


	// Use this for initialization
	void Start ()
	{
		isCompleted = false;
		isFailed = false;
		isGameOver = false;
		isPaused = false;
		boxBg.SetActive (false);
		compAnim = compBox.GetComponent<Animator> ();
		failAnim = failBox.GetComponent<Animator> ();
		pauseAnim = pauseBox.GetComponent<Animator> ();
		isHumanHit = false;
		wonCoins = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{

		NoOfMoves.text = shooot.AvlblMoves.ToString ();
//		AvlblTxt.text = shooot.hittedTargets.ToString () + " / " + shooot.TragetNo.ToString ();
		AvlblTxt.text = (shooot.TragetNo - shooot.hittedTargets).ToString ();

		// For Completed
		if (shooot.AvlblMoves >= 0 && shooot.hittedTargets == shooot.TragetNo && !isFailed && !isCompleted && !isPaused) {
			isCompleted = true;
			isGameOver = true;
			print ("<color=yellow>*****COMPLETED****</color>");
			StartCoroutine (BoxEffectWithWait (compAnim, 0.5f, "Open"));
		
			Adcontrol.instace.showAd();
			levelUnlockCkeck ();
			if (PlayerPrefs.GetInt ("SoundStatus") == 0) {
				Instantiate (winSound, Vector3.zero, Quaternion.identity);
			}
			CoinsCalulation (compAnim.transform);


		}

		if (((shooot.AvlblMoves == 0 && shooot.hittedTargets < shooot.TragetNo) || isHumanHit) && !isFailed && !isCompleted && !isPaused) {
			isFailed = true;
			isGameOver = true;
			print ("<color=yellow>xxxxxFAILEDxxxxx</color>");
			StartCoroutine (BoxEffectWithWait (failAnim, 0.5f, "Open"));
			Adcontrol.instace.showAd();
			StartCoroutine(soundPlay(0.5f,failSound));

		}


	}

	IEnumerator BoxEffectWithWait (Animator anim, float waitTime, string parameterName)
	{
		yield return new WaitForSeconds (waitTime);
		anim.SetTrigger (parameterName);
		if ((isCompleted || isFailed || isPaused) && parameterName == "Open") {
			boxBg.SetActive (true);
		} else {
			boxBg.SetActive (false);
		}
	}

	public void levelUnlockCkeck ()
	{
		if (PlayerPrefs.GetInt ("UnlockLevel") <= int.Parse (SceneManager.GetActiveScene ().name)) {
			PlayerPrefs.SetInt ("UnlockLevel", int.Parse (SceneManager.GetActiveScene ().name));
		}
	}
	// Pause Check;

	public void onPausedClick ()
	{
		if (!isFailed && !isCompleted) {
			isPaused = true;
			StartCoroutine (BoxEffectWithWait (pauseAnim, 0.5f, "Open"));
			Adcontrol.instace.showAd();
		}
	}

	public void onResumeClick ()
	{
		isPaused = false;
		StartCoroutine (BoxEffectWithWait (pauseAnim, 0f, "Close"));
	}

	public void CoinsCalulation (Transform go)
	{
		wonCoins = (shooot.AvlblMoves * 10) + 10;
		print ("WonCoins::: " + wonCoins);
		PlayerPrefs.SetInt ("AvlblCoins", PlayerPrefs.GetInt ("AvlblCoins") + wonCoins);

		go.GetChild (0).GetComponent<Text> ().text = "Earn Coin : " + wonCoins.ToString ();
		go.GetChild (1).GetComponent<Text> ().text = "Total Coin : " + PlayerPrefs.GetInt ("AvlblCoins").ToString ();
	}

	IEnumerator soundPlay (float waitTime, GameObject soundObj)
	{
		yield return new WaitForSeconds (waitTime);
		if (PlayerPrefs.GetInt ("SoundStatus") == 0) {
			Instantiate (soundObj, Vector3.zero, Quaternion.identity);
		}
	}


}
