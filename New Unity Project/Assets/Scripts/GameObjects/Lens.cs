using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lens : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void SetColor(Color col)
	{
		this.gameObject.GetComponent<SpriteRenderer>().color = col;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
