using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallScript : MonoBehaviour {
	public Animator Bamboo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.name == "Arrow" && name=="Ball") {
			name="BallObj";
			Bamboo.SetTrigger ("Down");
//			gameObject.SetActive (false);
		}

	}
}
