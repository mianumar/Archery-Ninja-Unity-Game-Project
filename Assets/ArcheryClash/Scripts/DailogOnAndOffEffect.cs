using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailogOnAndOffEffect : MonoBehaviour {
	[HideInInspector]
	public bool isOn, isOff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(isOn)
		{
			transform.localScale = Vector3.Lerp (transform.localScale, Vector3.one, 0.1f);
		}
		if(isOff)
		{
			transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.1f);
		}
	}

}
