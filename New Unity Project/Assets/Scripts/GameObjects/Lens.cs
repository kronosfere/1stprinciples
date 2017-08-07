using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lens : MonoBehaviour {

	[SerializeField]
	Color CurrentCol;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().color = CurrentCol;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
