using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimSelector : MonoBehaviour
{
	public enum StateName
	{
		Idle,
		OneApple,
		TwoApple,
		OneTwoApple,
		HandSeaSaw,
		HandSeaSaw2,
		AppleLR,
		AppleRL,
		WalkRight,
		Sitting,
		WalkFront,
		HandUpDown,
		PoseStand,
		LeanFront,
		LeanFront2,
		LeanFront3,
		Sit,
		SimpleStand
	}

	public StateName AnimState;
	// Use this for initialization
	void Start ()
	{
		GetComponent<Animator> ().Play (AnimState.ToString ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
