using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcherGameManager;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public GameObject[] levels;
	public GameObject playerController;
	//	private int currentLevel;
	private GameObject currentLevelGameObject;

	public static GameController GControlManager;
	//	public GameObject uiPanel;
	//	public Text levelNumberText;

	//	public GameObject levelNoText;
	//	public GameObject LevelStartUpSound;
	//	public Button NextBtn, BackBtn;
	//store boundary world positions

	// Use this for initialization
	void Start ()
	{
		PlayerPrefs.SetInt ("levelNos",0);


		if (PlayerPrefs.GetInt ("levelNos") >= levels.Length) {
			PlayerPrefs.SetInt ("levelNos", levels.Length - 1);
		}


		GameManager.instance.CurrentLevel = PlayerPrefs.GetInt ("levelNos");
		SetUpLevel ();
		GControlManager = this;
	}

	/// <summary>
	/// Sets up level.
	/// </summary>
	 public void SetUpLevel ()
	{
		
		StartCoroutine (SetUpGame (0));
	}

	IEnumerator SetUpGame (float waitTime)
	{
		GameManager.instance.CurrentGameState = GameState.PlayState;
		yield return new WaitForSeconds (waitTime);
		Destroy (currentLevelGameObject);
		currentLevelGameObject = (GameObject)GameObject.Instantiate (levels [GameManager.instance.CurrentLevel]);
//		ThemeController.InstanceTheme.setTheme (GameManager.instance.CurrentLevel+1);
	//	AdMobManager._AdMobInstance.loadInterstitial ();
	}


	/// <summary>
	/// Raises the level completion event.
	/// </summary>
	public void OnLevelCompletion ()
	{

		GameManager.instance.CurrentGameState = GameState.CompletedState;
//		onNextLevel ();
	}

	public void onNextLevel ()
	{
	//	AdMobManager._AdMobInstance.showInterstitial ();
		GameManager.instance.CurrentLevel++;
		//For Lock 
		if (GameManager.instance.CurrentLevel > PlayerPrefs.GetInt ("levelNos")) {
			PlayerPrefs.SetInt ("levelNos", GameManager.instance.CurrentLevel);

		}
		// End
		if (GameManager.instance.CurrentLevel >= levels.Length) {
			GameManager.instance.CurrentLevel = 0;

		}

		SetUpLevel ();
	}

	public void onPreviousLevel ()
	{
		GameManager.instance.CurrentLevel--;
		if (GameManager.instance.CurrentLevel < 0)
			GameManager.instance.CurrentLevel = 0;

		SetUpLevel ();
	}

	public void onNextClick ()
	{
		if (GameManager.instance.CurrentLevel < PlayerPrefs.GetInt ("levelNos")) {  //For Lock
			GameManager.instance.CurrentLevel++;
			if (GameManager.instance.CurrentLevel >= levels.Length)
				GameManager.instance.CurrentLevel = 0;

			SetUpLevel ();
		}
	}
// End


	public void loadAdOnGameSetup ()
	{

	}



	
}
