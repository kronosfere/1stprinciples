using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : BaseGameObject {

    [SerializeField]
    Quaternion Projectile_Direction;

    [SerializeField]
    public float Projectile_Speed = 1.0f;

    public virtual void Move()
    {
        this.transform.Translate(Projectile_Direction.eulerAngles * Projectile_Speed * Time.deltaTime);
    }

    public virtual void Set_Projectile_Direction(Quaternion newDir)
    {
        Projectile_Direction = newDir;
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
