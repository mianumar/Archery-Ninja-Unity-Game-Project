using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour 
{
	
	public bool forcoin;
	public int adscount;


	public static AdManager instance;

	void Awake ()
	{
	instance = this;
		
		
	}
	public int reset;


	void Start ()
	{
		gameObject.name = "AdManager";
	}




	

	public void give50points()
    {
		PlayerPrefs.SetInt("AvlblCoins", PlayerPrefs.GetInt("AvlblCoins") + 50);
	}

}



