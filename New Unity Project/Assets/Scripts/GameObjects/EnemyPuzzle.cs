﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPuzzle : MonoBehaviour
{

	[SerializeField]
	float HoverRange;
	[SerializeField]
	float HoverSpeed;
	[SerializeField]
	int LoadNextLevel;

	bool MovingUp = true;
	float HoverMidPoint;

	bool isDead = false;

	void Hover()
	{
		if (MovingUp)
		{
			Vector3 tmp = new Vector3(0, HoverSpeed * Time.deltaTime, 0);
			this.transform.Translate(tmp);

			if (HoverMidPoint + HoverRange < this.transform.position.y)
				MovingUp = false;
		}

		else
		{
			Vector3 tmp = new Vector3(0, -HoverSpeed * Time.deltaTime, 0);
			this.transform.Translate(tmp);

			if (HoverMidPoint - HoverRange > this.transform.position.y)
				MovingUp = true;
		}
	}

	// Use this for initialization
	void Start()
	{
		HoverMidPoint = this.transform.position.y;
	}

	void DeathAnimation()
	{
		transform.Rotate(new Vector3(0, 0, 8.0f));
		transform.localScale -= (new Vector3(0.005f, 0.005f));

		if (transform.localScale.x < 0.01f)
		{
			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}

			Destroy(this);

			if (LoadNextLevel != 0)
				Application.LoadLevel(LoadNextLevel);
			else
				Application.Quit();
		}
	}

	// Update is called once per frame
	void Update()
	{
		Hover();

		if(isDead)
		{
			DeathAnimation();
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Projectile" && isDead == false)
		{
			Color tmpCol = collision.gameObject.GetComponent<SpriteRenderer>().color;
			Color tmpthis = this.gameObject.GetComponent<SpriteRenderer>().color;

			bool checkR = tmpthis.r > 0.1f ? true : false;
			bool checkG = tmpthis.g > 0.1f ? true : false;
			bool checkB = tmpthis.b > 0.1f ? true : false;

			bool sameColor = true;

			if (checkR && tmpCol.r < 0.1f || !checkR && tmpCol.r > 0.1f)
				sameColor = false;
			if (checkG && tmpCol.g < 0.1f || !checkG && tmpCol.g > 0.1f)
				sameColor = false;
			if (checkB && tmpCol.b < 0.1f || !checkB && tmpCol.b > 0.1f)
				sameColor = false;

			if (sameColor)
			{
				isDead = true;

				// Destroy that projectile
				Destroy(collision.gameObject);
			}
		}
	}
}