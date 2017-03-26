using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLight : BaseGameObject {

    [SerializeField]
    float Cooldown_Fire;

    [SerializeField]
    float Projectile_Speed_Multiplier = 2.0f;
	[SerializeField]
	public float Projectile_Angle;

	public bool Is_Selected = false;
    
    private float Cooldown_Internal_Fire;

    void Fire()
    {
        try
        {
            GameObject Projectile = (GameObject)Instantiate(Resources.Load("Projectile/Projectile_Light"));
            Projectile.transform.position = this.transform.position;
            Projectile.GetComponent<ProjectileLight>().Projectile_Speed = Projectile.GetComponent<ProjectileLight>().Projectile_Speed * Projectile_Speed_Multiplier;
			Projectile.GetComponent<ProjectileLight>().Set_Projectile_Direction(Projectile_Angle);
        }

        catch
        {
            Debug.Log("Projectile not created!");
        }
    }

	// Update is called once per frame
	void Update () {
        Cooldown_Internal_Fire += Time.deltaTime;

        if(Cooldown_Internal_Fire > Cooldown_Fire)
        {
            Cooldown_Internal_Fire = 0.0f;
            Fire();
        }
	}
}
