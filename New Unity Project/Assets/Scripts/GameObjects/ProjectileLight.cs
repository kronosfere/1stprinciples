﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLight : BaseProjectile
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	override public void Update () {
        Move();
    }
}
