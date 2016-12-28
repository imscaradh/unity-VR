using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamUIController : MonoBehaviour
{
	public RawImage rawimage;

	private Camera mainCamera;

	void Start ()
	{
		WebCamTexture webcamTexture = new WebCamTexture ();
		rawimage.texture = webcamTexture;
		rawimage.material.mainTexture = webcamTexture;
		webcamTexture.Play ();

		mainCamera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		rawimage.rectTransform.SetAsLastSibling ();
	}
}