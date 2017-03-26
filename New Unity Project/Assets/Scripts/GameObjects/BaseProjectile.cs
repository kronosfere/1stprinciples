using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : BaseGameObject {

    [SerializeField]
    float Projectile_Angle;

    [SerializeField]
    public float Projectile_Speed = 1.0f;

    public virtual void Move()
    {
        this.transform.Translate(Quaternion.Euler(0, 0, Projectile_Angle) * Vector3.up  * Projectile_Speed * Time.deltaTime);
    }

    public virtual void Set_Projectile_Direction(float newAngle)
    {
        Projectile_Angle = newAngle;
    }

	// Update is called once per frame
	public virtual void Update () {
        //Move();
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            Destroy(this.gameObject);
        }
    }
}
