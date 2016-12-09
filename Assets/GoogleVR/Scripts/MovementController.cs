using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{

	private const int RIGHT_ANGLE = 90;

	// This variable determinates if the player will move or not
	private bool isWalking = false;

	GvrHead head = null;

	//This is the variable for the player speed
	[Tooltip ("With this speed the player will move.")]
	public float speed;

	[Tooltip ("Activate this checkbox if the player shall move when the Cardboard trigger is pulled.")]
	public bool walkWhenTriggered;

	[Tooltip ("Activate this checkbox if the player shall move when he looks below the threshold.")]
	public bool walkWhenLookDown;

	[Tooltip ("This has to be an angle from 0° to 90°")]
	public double thresholdAngle;

	void Start ()
	{
		head = Camera.main.GetComponent<StereoController> ().Head;
	}

	void Update ()
	{
		// Walk when the Cardboard Trigger is used 
		if (walkWhenTriggered && !walkWhenLookDown && !isWalking && GvrViewer.Instance.Triggered) {
			Walk ();
		} 

		// Walk when player looks below the threshold angle 
		if (walkWhenLookDown && !walkWhenTriggered && !isWalking &&
		    head.transform.eulerAngles.x >= thresholdAngle &&
		    head.transform.eulerAngles.x <= RIGHT_ANGLE) {
			Walk ();
		}

		// Walk when the Cardboard trigger is used and the player looks down below the threshold angle
		if (walkWhenLookDown && walkWhenTriggered && !isWalking &&
		    head.transform.eulerAngles.x >= thresholdAngle &&
		    GvrViewer.Instance.Triggered &&
		    head.transform.eulerAngles.x <= RIGHT_ANGLE) {
			Walk ();
		}
	}

	public void Walk ()
	{
		Vector3 direction = new Vector3 (head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
		transform.Translate (rotation * direction);
	}
		
}
