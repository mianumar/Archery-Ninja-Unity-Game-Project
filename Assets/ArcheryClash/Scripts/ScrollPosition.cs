using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float value = (PlayerPrefs.GetInt ("UnlockLevel") / 10) * 750;
		print (PlayerPrefs.GetInt ("UnlockLevel")/10+"          "+value);
		transform.localPosition = new Vector3 (transform.localPosition.x, value, transform.localPosition.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
