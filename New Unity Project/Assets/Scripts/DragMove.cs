using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
	private Quaternion originalRotation;
	private Vector3 startDelta = Vector3.zero;
	private CameraDrag mainCamera;
	[SerializeField]
	SpriteRenderer anchorSprite;
	[SerializeField]
	bool deletable = false;

	public void Start()
	{
		originalRotation = this.transform.rotation;

		mainCamera = GameObject.Find("Main Camera").GetComponent<CameraDrag>();
	}

	public void OnMouseDown()
	{
		InputIsDown();
		mainCamera.dragDisable = true;
		anchorSprite.color = new Color(anchorSprite.color.r, anchorSprite.color.g, anchorSprite.color.b, 1);
	}

	public void OnMouseDrag()
	{
		InputIsHeld();
		mainCamera.dragDisable = true;
		anchorSprite.color = new Color(anchorSprite.color.r, anchorSprite.color.g, anchorSprite.color.b, 1);
	}

	public void OnMouseUp()
	{
		mainCamera.dragDisable = false;
		anchorSprite.color = new Color(anchorSprite.color.r, anchorSprite.color.g, anchorSprite.color.b, 0.5f);
		if (deletable && Input.mousePosition.y < 135.0f)
		{
			Destroy(this.gameObject, 0.05f);
		}
	}

	public void InputIsDown()
	{
		Vector3 clickWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		startDelta = this.transform.position - clickWorld;

		try
		{
			GameObject deletObj = GameObject.FindGameObjectWithTag("DeleteButton");

			if (!deletObj)
				Debug.LogException(new System.Exception("Unable to find the Delete Button component!"));

			deletObj.GetComponent<DeleteButton>().TrackingThisLens = this.gameObject;
		}

		catch
		{
			Debug.Log("Unexpected error with Delete Button / Input down for object");
		}
	}

	public void InputIsHeld()
	{
		Vector3 clickWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.transform.position = clickWorld + startDelta;

		try
		{
			GameObject UITracker = GameObject.FindGameObjectWithTag("UITracker");

			if (!UITracker)
				Debug.LogException(new System.Exception("Unable to find the UITracker!"));

			UITracker.transform.position = this.transform.position;
			Color tmp = UITracker.GetComponent<SpriteRenderer>().color;
			tmp.a = 1.0f;
			UITracker.GetComponent<SpriteRenderer>().color = tmp;
		}

		catch
		{
			Debug.Log("Unexpected error with Delete Button / Input down for object");
		}
	}
}