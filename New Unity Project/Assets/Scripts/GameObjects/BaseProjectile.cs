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
		this.transform.Translate(Vector3.up  * Projectile_Speed * Time.deltaTime);
    }

    public virtual void Set_Projectile_Direction(float newAngle)
    {
		Projectile_Angle = newAngle;
		this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, Projectile_Angle);
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
