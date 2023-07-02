using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverWithWater : MonoBehaviour
{
	public bool isMovable;
	public float moveSpeed;

	public Transform endPos;

	private float startTime;
	private Vector3 startPos, initialPos;

	private bool isOnce, isTwice;
	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;
		initialPos = transform.position;
		isOnce = isTwice = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isMovable) {
			startTime += Time.deltaTime * 2F;
			transform.position = Vector3.Lerp (startPos, endPos.position, (Mathf.Sin (startTime * moveSpeed + Mathf.PI / 2) + 1) / 2);
		}

		if (WaterUpScript.noOfBallHitz == 1 && isOnce) {
			isOnce = false;
			startPos = startPos + new Vector3 (0, 0.5f, 0);
		}else if (WaterUpScript.noOfBallHitz == 2 && isTwice) {
			isTwice = false;
			startPos = startPos + new Vector3 (0, 1f, 0);
		}
	}
}
