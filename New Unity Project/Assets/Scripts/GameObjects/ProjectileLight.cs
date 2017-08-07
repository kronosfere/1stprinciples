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

		//else if(collision.gameObject.tag == "Tower_Reflector")
		if(collision.gameObject.tag == "Bounds")
		{
			// Calculate reflection vector
			float DotProduct = Vector3.Dot(this.transform.rotation * Vector2.up, Vector3.Normalize(collision.gameObject.transform.up));
			Vector3 ReflectedVector = this.transform.rotation * Vector2.up - 2 * (DotProduct * collision.gameObject.transform.up);
			// Set Vector
			this.gameObject.transform.up = ReflectedVector;
		}

		if(collision.gameObject.tag == "Lens")
		{
			Color currentCol = this.GetComponent<SpriteRenderer>().color;

			if (currentCol == Color.white)
				currentCol = Color.black;

			Color colliderCol = collision.gameObject.GetComponent<SpriteRenderer>().color;
			currentCol.r = (int)(currentCol.r + 0.5f) | (int)(colliderCol.r + 0.5f);
			currentCol.g = (int)(currentCol.g + 0.5f) | (int)(colliderCol.g + 0.5f);
			currentCol.b = (int)(currentCol.b + 0.5f) | (int)(colliderCol.b + 0.5f);
			this.GetComponent<SpriteRenderer>().color = currentCol;

			// Ignore collision but edit the color
			Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
		}

		if(collision.gameObject.tag == "Projectile")
		{
			Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
		}
	}
}
