using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// This script is attached to the main game GameObject (gameManager)

public class shooot : MonoBehaviour
{

	// Reference to the arrow object
	public GameObject arrow;
	// Reference to the cam objects
	public Camera aimCam;
	public Camera arrowCam;
	// Reference to the crosshair
	public GameObject crossHair;


	GameObject arrowGO;

	// are we shooting or drawing the bow
	bool isShooting;
	bool isDrawingBow;

	// Reference to the audio clips
	public AudioClip drawBow;
	public AudioClip releaseBow;
	public AudioClip fanfare;

	// needed for the aiming animation
	float fovMax = 60;
	float fovMin = 50;
	float fovAkt;
	// this var stores the wind speed
	float windSpeed;

	// count the shot arrows
	int arrowCount = 0;
	// which level are we in
	int level = 0;


	// References to HUD GUI
	//	public GameObject gameOverGO;


	public int NoOfMoves;
	public int NoOfTarget;

	public static int AvlblMoves, hittedTargets, TragetNo;

	// game states
	public enum GameStates
	{
		menu,
		game,
		gameOver,
	};


	private bool isDownReady, isUpReady;
	// set starting game state
	public GameStates gameState = GameStates.menu;

	//
	private float startTime, endTime;


	// This method is called if player clicks
	// on "Main Menu" button on game over screen
	//
	public void loadMainMenu ()
	{
		Application.LoadLevel ("menu");
	}

	private Animator BowAnimator;

	//
	// public void playAgain()
	//
	// This method is called if player clicks
	// on "play again" button on game over screen
	//

	public void playAgain ()
	{
		Application.LoadLevel ("archery");
	}



	//
	// public void Shooting(bool Shooting)
	//
	// This method is called from arrow.cs script
	// to show that shooting is allowed
	//

	public void Shooting (bool Shooting)
	{
		isShooting = Shooting;
	}
		

	// Use this for initialization
	void Start ()
	{
		NoOfTarget = GameObject.FindGameObjectsWithTag ("Target").Length;
		// disable the Game Over screen
//		gameOverGO.SetActive (false);
		// can we shoot?
		isShooting = false;
		// can we draw the bow
		isDrawingBow = false;
		// set camera properties
		fovAkt = fovMax;
		// disable all camera which are not used
		arrowCam.enabled = false;
		aimCam.enabled = false;
		// disable crosshair
		crossHair.SetActive (false);
//		targetCam.enabled = false;
		startTime = endTime = 0;
		setLevel (1);
		//Score Calculation
		TragetNo = NoOfTarget;
		hittedTargets = 0;
		AvlblMoves = NoOfMoves;

		isDownReady = true;
		isUpReady = false;

		//BowAnimator = aimCam.transform.GetChild (0).GetComponent<Animator> ();
		BowSelector (PlayerPrefs.GetInt ("Bow"));
		print (PlayerPrefs.GetInt ("Bow"));

	}

	public void setLevel (int _level)
	{
		// after setting the level play a fanfare sound
//		if (PlayerPrefs.GetInt ("SoundStatus") == 0) {
//			GetComponent<AudioSource> ().PlayOneShot (fanfare);
//		}
		// set the level
		level = _level;
		// change the actual gameState
		gameState = GameStates.game;

		aimCam.enabled = true;

	}




	// Update is called once per frame
	void Update ()
	{
		// check which state we are in
		switch (gameState) {
		// same for the game state
		case GameStates.game:
			if ((Input.GetButtonUp ("Fire1")) && !isShooting && !ScoresManager.isGameOver && !ScoresManager.isPaused) {
				endTime = Time.time;
				isDrawingBow = false;
//				print (startTime + "AND" + endTime);
				if ((endTime - startTime) > 1f) {
					BowAnimator.SetTrigger ("Release");
//					if (BowAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !BowAnimator.IsInTransition (0)) {
					if (PlayerPrefs.GetInt ("SoundStatus") == 0) {
						GetComponent<AudioSource> ().PlayOneShot (releaseBow);
					}
					arrowGO = Instantiate (arrow, aimCam.transform.position, Quaternion.Euler (new Vector3 (0, aimCam.transform.localEulerAngles.y - 90f, 360f - aimCam.transform.localEulerAngles.x))) as GameObject;
					arrowGO.name = "Arrow";
					arrowGO.GetComponent<arrowScript> ().shootArrow (aimCam.transform.localEulerAngles);
					// this time: backpack cam
					arrowGO.GetComponent<arrowScript> ().setCam (arrowCam, true);
					// main cam is the aim cam
					arrowGO.GetComponent<arrowScript> ().setMainCam (aimCam);
					arrowGO.GetComponent<arrowScript> ().setWindSpeed (windSpeed);
					arrowGO.GetComponent<arrowScript> ().setGameManager (gameObject);
					isShooting = true;

					fovAkt = fovMax;
					aimCam.fieldOfView = fovAkt;
//					}

//					AvlblMoves--;
					print ("<color=red>Up After 5 Sec</color>");
				} else {
					print ("<color=yellow>Up Before 5 Sec</color>");
					BowAnimator.SetTrigger ("StrToRI");
				}
//				aimCam.GetComponent<Animator> ().SetTrigger ("Idle");
				BowOscilationDisable(PlayerPrefs.GetInt("Bow"));
				crossHair.SetActive (false);
			}

			if ((Input.GetButtonDown ("Fire1")) && !isDrawingBow && !isShooting) {
//				GetComponent<AudioSource> ().PlayOneShot (drawBow);
//				isDrawingBow = true;
//				startTime = Time.time;
////				print ("<color=yellow>Down Done</color>");
//				print ("<color=blue>Inside Down</color>");
			}

			if (Input.GetButton ("Fire1") && !ScoresManager.isGameOver && !ScoresManager.isPaused) {
				fovAkt = fovAkt -= 0.5f;
				fovAkt = Mathf.Clamp (fovAkt, fovMin, fovMax);
				aimCam.fieldOfView = fovAkt;
//				if (!aimCam.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Moving")) {
//					aimCam.GetComponent<Animator> ().SetTrigger ("Moving");
//				}
				BowOscilationEnable(PlayerPrefs.GetInt("Bow"));

				if (!isDrawingBow && !isShooting) {
					if (PlayerPrefs.GetInt ("SoundStatus") == 0) {
						GetComponent<AudioSource> ().PlayOneShot (drawBow);
					}
					isDrawingBow = true;
					startTime = Time.time;
					crossHair.SetActive (true);
					BowAnimator.SetTrigger ("String");

					//				print ("<color=yellow>Down Done</color>");
					print ("<color=blue>Inside Down</color>");
				}
			}
			break;

//		case GameStates.gameOver:
//			gameOverGO.SetActive (true);
//			break;
		}
				
	}


	public void BowSelector (int _Value)
	{
		aimCam.transform.GetChild (_Value).gameObject.SetActive (true);
		BowAnimator = aimCam.transform.GetChild (_Value).GetComponent<Animator> ();
	}

	public void BowOscilationEnable (int bowNum)
	{
		if (bowNum == 0) {
			if (!aimCam.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Moving3")) {
				aimCam.GetComponent<Animator> ().SetTrigger ("Moving3");
			}
		} else if (bowNum == 1) {
			if (!aimCam.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Moving2")) {
				aimCam.GetComponent<Animator> ().SetTrigger ("Moving2");
			}
		} else if (bowNum == 2) {
			if (!aimCam.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Moving")) {
				aimCam.GetComponent<Animator> ().SetTrigger ("Moving");
			}
		}
	}
	public void BowOscilationDisable (int bowNum)
	{
		if (bowNum == 0) {
			
				aimCam.GetComponent<Animator> ().SetTrigger ("Idle3");
		
		} else if (bowNum == 1) {
			aimCam.GetComponent<Animator> ().SetTrigger ("Idle2");
		} else if (bowNum == 2) {
			aimCam.GetComponent<Animator> ().SetTrigger ("Idle");
		}
	}

}
