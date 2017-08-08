using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour {

	public GameObject TrackingThisLens;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void DeleteLens()
	{
		try
		{
			Destroy(TrackingThisLens);

			// Remove the alpha
			try
			{
				GameObject UITracker = GameObject.FindGameObjectWithTag("UITracker");

				if (!UITracker)
					Debug.LogException(new System.Exception("Unable to find the UITracker!"));


				Color tmpCol = UITracker.GetComponent<SpriteRenderer>().color;
				tmpCol.a = 0.0f;
				UITracker.GetComponent<SpriteRenderer>().color = tmpCol;
			}

			catch
			{
				Debug.Log("Unable to find the UITracker");
			}
		}

		catch
		{
			Debug.Log("Expected error with destroying object!");
		}
	}
}
