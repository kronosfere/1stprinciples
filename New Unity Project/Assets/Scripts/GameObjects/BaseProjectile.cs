using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : BaseGameObject {

    [SerializeField]
    public float Projectile_Angle;

    [SerializeField]
    public float Projectile_Speed = 1.0f;

    public virtual void Move()
    {
		transform.position += this.transform.up  * Projectile_Speed * Time.deltaTime;
    }

    public virtual void Set_Projectile_Direction(float newAngle)
    {
		Projectile_Angle = newAngle;
		this.transform.up = Quaternion.Euler(0, 0, newAngle) * Vector3.up;
	}

	// Update is called once per frame
	public virtual void Update () {
        //Move();
	}

    virtual public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bounds" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
