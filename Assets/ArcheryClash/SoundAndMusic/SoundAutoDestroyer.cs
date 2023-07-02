using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAutoDestroyer : MonoBehaviour {
	private AudioClip ac;
	// Use this for initialization
	void Start () {
		ac = GetComponent<AudioSource> ().clip;
		Invoke ("killSelf", ac.length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void killSelf()
	{
		Destroy (gameObject);
	}
}
