using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorValueUpdateScript : MonoBehaviour {

	[SerializeField]
	Transform inputobj;
	[SerializeField]
	GameObject outputobj;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (outputobj != null)
			outputobj.transform.rotation = inputobj.transform.rotation;
	}
}
