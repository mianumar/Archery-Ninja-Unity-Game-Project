using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreUIScript : MonoBehaviour
{

	public Button NoAdsBtn, Coins500Btn, Coins1000Btn, BackBtn, HomeBtn;
	public Text AvlblCoins;
	// Use this for initialization
	void Start ()
	{
		BackBtn.onClick.AddListener (OnBackClick);
		HomeBtn.onClick.AddListener (OnHomeClick);

		NoAdsBtn.onClick.AddListener (OnNoAdsClick);

		Coins500Btn.onClick.AddListener (OnCoins500Click);

		Coins1000Btn.onClick.AddListener (OnCoins1000Click);

	}

	// Update is called once per frame
	void Update ()
	{
		AvlblCoins.text = "Coins : " + PlayerPrefs.GetInt ("AvlblCoins");
	}


	public void OnNoAdsClick ()
	{
//		Purchaser.instance.BuyNonConsumable (Purchaser.kProductIDNonConsumable_noadd);
		print ("NoAds Clicked");
	}

	public void OnCoins500Click ()
	{
//		Purchaser.instance.BuyConsumable (Purchaser.kProductIDConsumable_coin500);
		print ("500 Clicked");
	}

	public void OnCoins1000Click ()
	{
//		Purchaser.instance.BuyConsumable (Purchaser.kProductIDConsumable_coin1000);
		print ("1000 Clicked");
	}






	public void OnBackClick ()
	{
		SceneManager.LoadScene ("Shop");
	}

	public void OnHomeClick ()
	{
		SceneManager.LoadScene ("Home");
	}
}
