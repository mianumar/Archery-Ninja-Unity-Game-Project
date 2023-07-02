using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUIScreenScript : MonoBehaviour
{
	public Button GoBtn, HomeBtn, StoreBtn, WatchVideoBtn;
	public Text AvlblCoins;
	public static ShopUIScreenScript instace;
	// Use this for initialization

	private void Awake()
	{
		instace = this;
	}
	void Start ()
	{
		GoBtn.onClick.AddListener (OnGoClick);
		HomeBtn.onClick.AddListener (OnHomeClick);
//		StoreBtn.onClick.AddListener (OnStoreClick);
		WatchVideoBtn.onClick.AddListener (OnWatchVideoClick);


	}

	// Update is called once per frame
	void Update ()
	{
		AvlblCoins.text = "Coins : " + PlayerPrefs.GetInt ("AvlblCoins");

//		if (AdMobManager.rewardBasedVideo.IsLoaded) {
//			WatchVideoBtn.interactable = true;
//		} else {
//			WatchVideoBtn.interactable = false;
//		}
	}

	public void OnGoClick ()
	{
		SceneManager.LoadScene ("Level");
	}

	public void OnHomeClick ()
	{
		SceneManager.LoadScene ("Home");
	}

	public void OnStoreClick ()
	{
		SceneManager.LoadScene ("Store");
	}

	public void OnWatchVideoClick ()
	{
//		SceneManager.LoadScene ("Home");
		
		Adcontrol.instace.ShowRewardedVideo();

		print ("Call Watch Video");
	}

	
}
