﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerReflectors : BaseGameObject {

    [SerializeField]
    float ReflectorAngle;
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BaseGameObject tmpObj = collision.gameObject.GetComponent<BaseGameObject>();

        // Check if the beam is the owner's
        if (tmpObj.GameObjectOwner == this.GetComponent<BaseGameObject>().GameObjectOwner)
        {
            // Redirect if it is a beam, else do nothing
            if(tmpObj.GameObjType == BaseGameObject.GameObjectType.GAMEOBJ_PROJECTILE_LIGHT)
            {
                // Create a beam at reflected angle
            }
        }

        // Take damage if projectile is not owner's
        else
        {

        }
    }
}
