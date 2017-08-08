using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLight : BaseProjectile
{
	[SerializeField]
	bool fade = false;

	[SerializeField]
	bool trailing = true;

	private float LifeTime;
	private float LockDelta;
	private float fadeRate;
	private float trailRate = 0.02f;
	private float trailTrack;

	// Use this for initialization
	void Start () {
		trailTrack = trailRate;
	}
	
	public void SetLifeTime(float LT)
	{
		fade = true;
		LifeTime = LT;
		fadeRate = this.GetComponent<SpriteRenderer>().color.a / LifeTime;
	}

	private void Fading()
	{
		float tmp = this.GetComponent<SpriteRenderer>().color.a;
		Color col = this.GetComponent<SpriteRenderer>().color;
		col.a = (tmp - (fadeRate * Time.deltaTime));
		this.GetComponent<SpriteRenderer>().color = col;

		if (col.a < 0.0)
			Destroy(this);
	}

	private void Trails()
	{
		trailTrack -= Time.deltaTime;

		if (trailTrack < 0.0f)
		{
			trailTrack = trailRate;

			// Create projectile trials
			GameObject trails = (GameObject)Instantiate(Resources.Load("Projectile/Trails"));
			trails.transform.position = this.transform.position;
			trails.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
		}
	}

	// Update is called once per frame
	override public void Update () {
        Move();

		if (fade)
			Fading();

		if (trailing)
			Trails();
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

			if(currentCol.r > 0.9f && currentCol.g > 0.9f && currentCol.b > 0.9f)
			{
				currentCol.r = 0.0f;
				currentCol.g = 0.0f;
				currentCol.b = 0.0f;
				this.GetComponent<SpriteRenderer>().color = currentCol;
			}

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
