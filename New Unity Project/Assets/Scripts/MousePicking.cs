using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePicking : MonoBehaviour {

	[SerializeField]
	GameObject SelectedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if(hit.collider != null)
				SelectedObject = hit.collider.gameObject;

			if (SelectedObject)
			{
				while (SelectedObject.transform.parent)
				{
					SelectedObject = SelectedObject.transform.parent.gameObject;
				}
			}

			//if (hit.collider != null)
			//{
			//	Debug.Log("Selected: " + hit.collider.gameObject.tag);
			//}
		}

		if (SelectedObject && SelectedObject.tag == "Tower_Reflector")
		{
			if (Input.GetKeyUp(KeyCode.Delete))
			{
				Destroy(SelectedObject);
			}
		}
	}
}
