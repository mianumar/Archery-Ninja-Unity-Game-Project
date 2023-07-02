using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
	public Sprite LockSprt;
	public Sprite UnlockSprt;
	private Text noTxt;
	// Use this for initialization
	void Start () {
		noTxt = GetComponentInChildren<Text> ();
		noTxt.text = name;
		GetComponent<Button>().onClick.AddListener(onClick);
		levelLockCheck ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onClick()
	{
		SceneManager.LoadScene (name);
	}


	public void levelLockCheck ()
	{
		if ((int.Parse (name) - 1) <= PlayerPrefs.GetInt ("UnlockLevel")) {
			GetComponent<Button> ().interactable = true;
			GetComponent<Image> ().sprite = UnlockSprt;
			noTxt.text = name;
		} else {
			GetComponent<Button> ().interactable = false;
			noTxt.text = "";
			GetComponent<Image> ().sprite = LockSprt;

		}
	}

}
