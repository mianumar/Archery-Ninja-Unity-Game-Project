using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUIScript : MonoBehaviour {
	public Button PlayBtn;
	// Use this for initialization
	void Start () {
		PlayBtn.onClick.AddListener(OnPlay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnPlay()
	{
		SceneManager.LoadScene ("Shop");
	}
	public void OnReset()
	{
		PlayerPrefs.DeleteAll ();
	}
	public void OnExit()
	{
		Application.Quit ();
	}

	public void rate()
	{
		Application.OpenURL("");
	}

	public void moregames()
	{
		Application.OpenURL("");
	}
}
