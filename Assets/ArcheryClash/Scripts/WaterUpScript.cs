using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUpScript : MonoBehaviour
{
	public static bool isWaterUp;
	public static int noOfBallHitz;
	private Vector3 end1, end2;
	// Use this for initialization
	void Start ()
	{
		isWaterUp = false;
		noOfBallHitz = 0;
		end1 = transform.position + new Vector3 (0, 0.5f, 0);
		end2 = transform.position + new Vector3 (0, 1f, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isWaterUp && noOfBallHitz == 1) {
			transform.position = Vector3.Lerp (transform.position, end1, 0.05f);
		} else if (isWaterUp && noOfBallHitz == 2) {
			transform.position = Vector3.Lerp (transform.position, end2, 0.05f);
		}
	}
}
