using UnityEngine;
using System.Collections;


/// <summary>
/// In charge to move and rotate gameobject
/// </summary>
public class MoverRotator : MonoBehaviour
{

	public bool isRotate;
	public bool isMovable;
	public float rotateSpeed;
	public float moveSpeed;

	public Transform endPos;

	private float startTime;
	private Vector3 startPos;

	public enum rotDirection
	{
		Forward,
		Left,
		Right,Up}

	;

	public rotDirection RotationDir = rotDirection.Forward;

	void Start ()
	{
		startPos = transform.position;
	}

	
	void Update ()
	{
		if (isRotate) {
			if (RotationDir == rotDirection.Forward) {
				transform.Rotate (Vector3.forward * Time.deltaTime * 10 * rotateSpeed);
			} else if (RotationDir == rotDirection.Left) {
				transform.Rotate (Vector3.left * Time.deltaTime * 10 * rotateSpeed);
			} else if (RotationDir == rotDirection.Right) {
				transform.Rotate (Vector3.right * Time.deltaTime * 10 * rotateSpeed);
			}else if (RotationDir == rotDirection.Up) {
				transform.Rotate (Vector3.up * Time.deltaTime * 10 * rotateSpeed);
			}
		}

		if (isMovable) {
			startTime += Time.deltaTime * 2F;
			transform.position = Vector3.Lerp (startPos, endPos.position, (Mathf.Sin (startTime * moveSpeed + Mathf.PI / 2) + 1) / 2);
		}
	}
}
