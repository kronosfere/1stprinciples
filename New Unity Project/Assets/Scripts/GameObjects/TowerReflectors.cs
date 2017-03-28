using System.Collections;
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

        // Check if the beam is the owner's, if not owner's, take damage
        if (tmpObj.GameObjectOwner != this.GetComponent<BaseGameObject>().GameObjectOwner)
        {
			// Take damage
        }
    }
}
