using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour {

	[SerializeField]
	float RotateSpeed = 0;
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0, 0, RotateSpeed);
	}
}
