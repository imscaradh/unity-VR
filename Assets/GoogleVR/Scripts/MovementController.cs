using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
	public float speed;
	public float speedUp;

	private bool speedUpActive = false;


	void Start ()
	{
	}

	void Update ()
	{

		// TODO: Improve if-else (could be smarter)
		if (GvrViewer.Instance.Triggered && speedUpActive) {
			speedUpActive = false;
			Debug.Log ("Speedup deactivated");
		} else if (GvrViewer.Instance.Triggered && !speedUpActive) {
			speedUpActive = true;
			Debug.Log ("Speedup activated");
		}
		Walk (speedUpActive ? speedUp : speed);
	}


	void Walk (float _speed)
	{
		transform.position += transform.forward * _speed * Time.deltaTime;
	}
}
