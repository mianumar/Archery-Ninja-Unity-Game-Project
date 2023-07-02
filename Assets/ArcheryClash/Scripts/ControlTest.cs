using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			print ("<color=red>Mouse Button Down 111111</color>");
		}
		if (Input.GetMouseButton (0)) {
			print ("<color=green>Mouse Button Down 222222</color>");
		}
		if (Input.GetMouseButtonUp (0)) {
			print ("<color=yellow>Mouse Button Down 333333</color>");
		}

	}
}
