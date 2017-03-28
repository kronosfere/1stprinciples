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
			// If it collides on the mirror surface
			if (Vector3.Dot(collision.gameObject.transform.up, Quaternion.Euler(0, 0, Projectile_Angle) * Vector3.up) > 0.0f)
			{
				Debug.Log(collision.gameObject.transform.up);

				if(collision.gameObject.transform.up.y > 0.0f)
					Projectile_Angle -= 90.0f;

				else
					Projectile_Angle += 90.0f;
			}

			else
			{
				Destroy(this.gameObject);
			}
		}
	}
}
