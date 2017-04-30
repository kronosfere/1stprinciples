using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour {

	private Quaternion originalRotation;
	private float startAngle = 0;
	private CameraDrag mainCamera;

	public void Start()
	{
		originalRotation = this.transform.rotation;

		mainCamera = GameObject.Find("Main Camera").GetComponent<CameraDrag>();
	}

	public void OnMouseDown()
	{
		InputIsDown();
		mainCamera.dragDisable = true;
	}

	public void OnMouseDrag()
	{
		InputIsHeld();
		mainCamera.dragDisable = true;
	}

	public void OnMouseUp()
	{
		mainCamera.dragDisable = false;
		
	}

	public void InputIsDown()
	{
		originalRotation = this.transform.rotation;
		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 vector = Input.mousePosition - screenPos;
		startAngle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
		//startAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;  // uncomment to pop to where mouse is 
	}

	public void InputIsHeld()
	{
		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 vector = Input.mousePosition - screenPos;
		float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
		Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle, this.transform.forward);
		newRotation.y = 0; //see comment from above 
		newRotation.eulerAngles = new Vector3(0, 0, newRotation.eulerAngles.z);
		this.transform.rotation = originalRotation * newRotation;
	}
}
