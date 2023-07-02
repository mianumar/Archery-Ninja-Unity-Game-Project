using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBowScript : MonoBehaviour
{
	public int BowPrice, tempAvlblCoin;
	private Button LockButton;
	public Sprite ActiveSprt, InActiveSprt;

	private Image selectBox;
	public Sprite selectSprt, selectedSprt, unlockSprt;
	private GameObject priceBox;
	//	private int clickCount;

	// Use this for initialization
	void Start ()
	{
//		PlayerPrefs.SetInt (name, 0);
//		PlayerPrefs.SetInt ("AvlblCoins", tempAvlblCoin);
//		PlayerPrefs.SetInt ("Bow", 0);
		selectBox = transform.GetChild (1).GetComponent<Image> ();
		priceBox = transform.GetChild (2).gameObject;
		if (name != "0") {
			LockButton = transform.GetChild (0).GetComponent<Button> ();
			if (PlayerPrefs.GetInt (name) == 0) {
				LockButton.gameObject.SetActive (true);
				GetComponent<Button> ().interactable = false;
				LockButton.interactable = false;
				GetComponent<Image> ().sprite = InActiveSprt;
				selectBox.sprite = unlockSprt;
				priceBox.SetActive (true);
			} else {
				GetComponent<Image> ().sprite = ActiveSprt;
				LockButton.gameObject.SetActive (false);
				GetComponent<Button> ().interactable = true;
				priceBox.SetActive (false);
			}
			LockButton.onClick.AddListener (onLockClick);
		}
		GetComponent<Button> ().onClick.AddListener (onSelectArrow);




	}
	
	// Update is called once per frame
	void Update ()
	{
		if (name != "0") {
			if (PlayerPrefs.GetInt ("AvlblCoins") > BowPrice && PlayerPrefs.GetInt (name) == 0) {
				LockButton.interactable = true;
			} else {
				LockButton.interactable = false;
			}
		}



		if (PlayerPrefs.GetInt ("Bow") == int.Parse (name)) {
			selectBox.sprite = selectedSprt;
		} else {
			if (PlayerPrefs.GetInt (name) == 0 && name != "0") {
				selectBox.sprite = unlockSprt;
			} else {
				selectBox.sprite = selectSprt;
			}
		}
	}

	public void onLockClick ()
	{
		LockButton.gameObject.SetActive (false);
		GetComponent<Button> ().interactable = true;
		PlayerPrefs.SetInt (name, 1);
		GetComponent<Image> ().sprite = ActiveSprt;
		PlayerPrefs.SetInt ("AvlblCoins", PlayerPrefs.GetInt ("AvlblCoins") - BowPrice);
		priceBox.SetActive (false);
	}

	public void onSelectArrow ()
	{
//		clickCount++;
		PlayerPrefs.SetInt ("Bow", int.Parse (name));
	}
}
