using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Trail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 tmp = this.transform.localScale;
		tmp = Vector3.Scale(tmp, new Vector3(0.99f, 0.99f, 0.99f));
		this.transform.localScale = tmp;

		if (this.transform.localScale.x < 0.01f)
		{
			Destroy(this.gameObject);
		}
	}
}
