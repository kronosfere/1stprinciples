using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLight : BaseProjectile
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	override public void Update () {
        Move();
    }

	override public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bounds" || collision.gameObject.tag == "Ground")
		{
			Destroy(this.gameObject);
		}

		else if(collision.gameObject.tag == "Tower_Reflector")
		{
			Vector3 tmp = collision.gameObject.transform.localRotation * Vector3.up;

			// If it is angled down
			if(tmp.y > 0.0f)
				Projectile_Angle -= 90;

			// If it is angled up
			else
				Projectile_Angle += 90;
		}
	}
}
