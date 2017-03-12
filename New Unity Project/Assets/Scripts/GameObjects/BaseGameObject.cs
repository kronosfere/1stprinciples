using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameObject : MonoBehaviour {

    public enum GameObjectType
    {
        GAMEOBJ_LIGHT_TOWER = 0,
        GAMEOBJ_LIGHT_REFLECT,
        GAMEOBJ_LIGHT_BEAM,
        GAMEOBJ_TOTAL_TYPE
    };

    [SerializeField]
    public GameObjectType GameObjType;
    [SerializeField]
    public uint GameObjectOwner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
