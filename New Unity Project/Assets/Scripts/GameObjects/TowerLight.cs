using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLight : BaseGameObject {

    [SerializeField]
    float Cooldown_Fire;
    
    private float Cooldown_Internal_Fire;

    void Fire()
    {
        //GameObject Projectile = (GameObject)Instantiate(Resources.Load("Projectile_Light"));
        Debug.Log("Fire");
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
