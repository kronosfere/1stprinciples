using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : BaseGameObject
{
	[SerializeField]
	float Cooldown_Fire;
	[SerializeField]
	float Projectile_Speed_Multiplier = 2.0f;
	[SerializeField]
	public float Projectile_Angle;

	public bool Is_Selected = false;
	private float Cooldown_Internal_Fire;

	// Origin_Fire_Position dictates where the tower's projectile will fire from
	Vector3 Origin_Fire_Position;

	public virtual void BaseStart()
	{
		Origin_Fire_Position = this.transform.position;
	}

    void Fire()
	{
		try
		{
			GameObject Projectile = (GameObject)Instantiate(Resources.Load("Projectile/Projectile_Light"));
			// Sets projectile position
			Projectile.transform.position = Origin_Fire_Position;
			// Sets the projectile direction
			Projectile.GetComponent<ProjectileLight>().Set_Projectile_Direction(Projectile_Angle);
			Projectile.GetComponent<ProjectileLight>().Projectile_Speed = Projectile.GetComponent<ProjectileLight>().Projectile_Speed * Projectile_Speed_Multiplier;
		}

		catch
		{
			Debug.Log("Projectile not created!");
		}
	}

	public virtual void BaseUpdate()
	{
		Cooldown_Internal_Fire += Time.deltaTime;

		if (Cooldown_Internal_Fire > Cooldown_Fire)
		{
			Cooldown_Internal_Fire = 0.0f;
			Fire();
		}
	}
}
