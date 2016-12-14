using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
	public float speed;
	public float speedUp;

	private GvrHead head;

	void Start ()
	{
		head = Camera.main.GetComponent<StereoController> ().Head;
	}

	void Update ()
	{
		if (GvrViewer.Instance.Triggered) {
			Walk (speedUp);
		} else {
			Walk (speed);
		}
	}

	void Walk (float _speed)
	{
		Debug.Log (_speed);
		transform.position += transform.forward * _speed * Time.deltaTime;
	}
}
