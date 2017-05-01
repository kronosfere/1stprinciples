using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButton : MonoBehaviour {
	//private GameObject instance;
	// Use this for initialization
	void Start () {
		//instance = this.transform.FindChild("Object").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BtnCreateObject()
	{
		GameObject newObj = (GameObject)Instantiate(Resources.Load("Towers/LightReflectors"));
		newObj.SetActive(true);
		newObj.transform.position = Vector3.zero;
	}
}
