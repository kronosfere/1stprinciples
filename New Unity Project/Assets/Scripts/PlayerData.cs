using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public enum PlayerIDEnum
    {
        PlayerOne = 0,
        PlayerTwo,
        InvalidPlayer
    };

    // This field will be filled by the server in a future build
    [SerializeField]
    public PlayerIDEnum PlayerID = PlayerIDEnum.InvalidPlayer;
}
