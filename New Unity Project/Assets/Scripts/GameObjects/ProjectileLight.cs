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
		// Create Particles
		GameObject particles = (GameObject)Instantiate(Resources.Load("Particles/Particle_Collision_Light"));
		particles.transform.position = this.transform.position;
		Destroy(particles, 1.5f);

		if (collision.gameObject.tag == "Bounds" || collision.gameObject.tag == "Ground")
		{
			Destroy(this.gameObject);
		}

		else if(collision.gameObject.tag == "Tower_Reflector")
		{
			// If it collides on the mirror surface
			if (Vector3.Dot(collision.gameObject.transform.up, Quaternion.Euler(0, 0, this.gameObject.transform.eulerAngles.z) * Vector3.up) > 0.0f)
			{
				if (collision.gameObject.transform.up.y > 0.0f)
					this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z - 90);

				else
					this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z + 90);
				// Calculate reflection vector
				//float DotProduct = Vector3.Dot((this.gameObject.transform.eulerAngles.z * Vector3.up), Vector3.Normalize(collision.gameObject.transform.up));
				//Vector3 ReflectedVector = this.gameObject.transform.eulerAngles.z * Vector3.up - 2 * (DotProduct * collision.gameObject.transform.up);
				//// Set Vector
				//this.gameObject.transform.eulerAngles = ReflectedVector;
			}

			else
			{
				Destroy(this.gameObject);
			}
		}
	}
}
