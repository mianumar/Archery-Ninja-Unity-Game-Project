using UnityEngine;
using System.Collections;

// This script is attached to the target itself
// It calculates the score is case the target is been hit

public class targetHit : MonoBehaviour
{

	// Reference to the rising text which is displayed is arrow hits target
	//	public GameObject risingText;
	// Reference to main Game Object to manage score
	//	public GameObject gameManager;
	//Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		//	rb = GetComponent<Rigidbody> ();
		//	rb.constraints = RigidbodyConstraints.FreezeAll;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}



	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.name == "Arrow") {
			
			StartCoroutine (waitAndGo (0.1f, other.gameObject));

		}

	}

	IEnumerator waitAndGo (float waitTime, GameObject other)
	{
		yield return new WaitForSeconds (waitTime);
		if (GetComponent<Rigidbody> () == null) {
			
			Destroy (other.gameObject.GetComponent<Rigidbody> ());
			transform.tag = "Ground";
			if (gameObject.layer != 9) {
				GetComponent<MeshCollider> ().convex = true;
				gameObject.AddComponent<Rigidbody> ();
				GetComponent<Rigidbody> ().AddForce (new Vector3 (1, 0.5f, 0) * 02, ForceMode.Impulse);
			}

			if (GetComponent<MoverRotator> () != null) {
				Destroy (GetComponent<MoverRotator> ());
			}

			if (gameObject.layer != 9) {
				DestroySelf ();
			}
		}
//		rb.constraints = RigidbodyConstraints.None;
//		rb.useGravity = true;
		//rb.AddForce (new Vector3 (1, 0.5f, 0) * 05, ForceMode.Impulse);
	}

	public void DestroySelf ()
	{
		Destroy (gameObject, 2);
	}

}
