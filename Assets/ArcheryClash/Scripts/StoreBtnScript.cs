using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreBtnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (OnBtnClick);
	}
	
	// Update is called once per frame
	void OnBtnClick () {
		SceneManager.LoadScene ("Store");
	}
}
