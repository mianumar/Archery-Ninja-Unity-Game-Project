using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimAutoDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float t = GetComponent<Animator> ().GetCurrentAnimatorClipInfo (0).Length;
		Destroy (gameObject, t);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
