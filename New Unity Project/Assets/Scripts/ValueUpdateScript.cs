using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueUpdateScript : MonoBehaviour {

	[SerializeField]
	Transform inputobj;
	[SerializeField]
	TowerLight outputobj;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		outputobj.Projectile_Angle = inputobj.transform.rotation.eulerAngles.z;
	}
}
