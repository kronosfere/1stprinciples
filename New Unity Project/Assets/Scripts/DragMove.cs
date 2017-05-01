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
	}

	public void InputIsDown()
	{
		Vector3 clickWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		startDelta = this.transform.position - clickWorld;
	}

	public void InputIsHeld()
	{
		Vector3 clickWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.transform.position = clickWorld + startDelta;
	}
}