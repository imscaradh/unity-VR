using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
	public float speed;
	public float speedUp;

	private bool speedUpActive = false;

	GameObject menuCanvas;

	void Start ()
	{
		WebCamDevice[] devices = WebCamTexture.devices;
		for( int i = 0 ; i < devices.Length ; i++ )
			Debug.Log(devices[i].name);  
		
		menuCanvas = GameObject.FindWithTag ("Menu");
	}

	void Update ()
	{
		MoveMenu ();

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

	void MoveMenu ()
	{
		// Position
		Vector3 pos = transform.position;
		pos.y = menuCanvas.transform.position.y;
		menuCanvas.transform.position = pos;

		// Rotation
		Vector3 rotAngles = menuCanvas.transform.eulerAngles;
		rotAngles.y = transform.eulerAngles.y;
		menuCanvas.transform.eulerAngles = rotAngles;
	}

	void Walk (float _speed)
	{
		transform.position += transform.forward * _speed * Time.deltaTime;
	}
}
