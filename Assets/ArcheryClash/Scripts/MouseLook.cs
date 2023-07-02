using UnityEngine;
using System.Collections;

[AddComponentMenu ("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2

	}

	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;
	private Vector3 initAngle;

	void Update ()
	{
		float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivityX;
		rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);

		rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		if (!ScoresManager.isGameOver && !ScoresManager.isPaused) {
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		}
	}

	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody> ())
			GetComponent<Rigidbody> ().freezeRotation = true;

		initAngle = transform.localEulerAngles;

		minimumX = initAngle.y - 50;
		maximumX = initAngle.y + 50;

		minimumY = initAngle.x - 5;
		maximumY = initAngle.x + 20;

	}
}