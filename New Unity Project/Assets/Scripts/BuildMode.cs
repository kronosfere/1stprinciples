using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour {

	bool buildMode = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("b"))
		{
			buildMode = !buildMode;
		}

		if (buildMode)
		{
			// If Left Click
			if (Input.GetMouseButtonUp(0))
			{
				GameObject Projectile = (GameObject)Instantiate(Resources.Load("Towers/LightReflectors"));
				Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				tmp.z = 0.0f;
				Projectile.transform.position = tmp;
			}
		}
	}
}
