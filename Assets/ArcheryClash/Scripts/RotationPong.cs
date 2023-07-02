using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPong : MonoBehaviour {
	public float speed;
	public Vector3 fromVector;
	public Vector3 toVector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float t = Mathf.PingPong(Time.time * speed, 1.0f);
		Quaternion fromV = Quaternion.Euler (fromVector);
		Quaternion toV = Quaternion.Euler (toVector);
		transform.localRotation = Quaternion.Lerp (fromV, toV, t);
	}
}
