using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour {
	private Vector3 startPos,endPos;
	public Transform target;
	public float speed,waitTime;
	private bool isReady;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		endPos = target.position;
		isReady = false;
		Invoke ("isReadyCheck", waitTime);

	}
	
	// Update is called once per frame
	void Update () {
		if (isReady) {
			transform.position = Vector3.MoveTowards (transform.position, 
				endPos, speed * Time.deltaTime); 

			if (transform.position.z == endPos.z) { 

				transform.position = startPos;

				transform.position = Vector3.MoveTowards (transform.position, 
					endPos, speed * Time.deltaTime); 

			}
		}
	}
	public void isReadyCheck()
	{
		isReady = true;
	}
}
