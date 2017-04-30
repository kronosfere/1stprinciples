using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPuzzle : MonoBehaviour
{

	[SerializeField]
	float HoverRange;
	[SerializeField]
	float HoverSpeed;

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
			isDead = true;

			// Destroy that projectile
			Destroy(collision.gameObject);
		}
	}
}