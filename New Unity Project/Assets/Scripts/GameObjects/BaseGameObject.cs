using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameObject : MonoBehaviour {

    public enum GameObjectType
    {
        GAMEOBJ_TOWER_LIGHT = 0,
        GAMEOBJ_TOWER_REFLECT,
        GAMEOBJ_PROJECTILE_LIGHT,
        GAMEOBJ_TOTAL_TYPE
    };

    [SerializeField]
    public GameObjectType GameObjType;
    [SerializeField]
    public PlayerData.PlayerIDEnum GameObjectOwner;
    [SerializeField]
    Quaternion GameObject_Rotation;

	// Use this for initialization
	void Start () {
        GameObjectOwner = GameObject.Find("GameController").GetComponent<PlayerData>().PlayerID;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
