﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : RoleBase
{

    private void Awake()
    {
        base.RoleInitInfo();
    }

    private void Update() 
    {
        base.RoleUpDate();
        base.attackType.UseSkill();
        base.attackType.Dead();
    }
    
}
