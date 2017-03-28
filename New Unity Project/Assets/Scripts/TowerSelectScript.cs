using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectScript : BaseSelectableArea {

	[SerializeField]
	GameObject Selector;

	void OnMouseDown()
	{
		Selector.SetActive(true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
