using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObject : MonoBehaviour
{

	[SerializeField]
	public float ScrollSpeed = 0.01f;

	float LeftBound;

	public void SetScrollSpeed(float setSpd)
	{
		ScrollSpeed = setSpd;
		LeftBound = GameObject.Find("Left_Bound").transform.position.x;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 tmp = new Vector3(-ScrollSpeed, 0, 0);
		this.transform.Translate(tmp * Time.deltaTime);

		if (this.transform.position.x < LeftBound)
			Destroy(this.gameObject);
	}
}