using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : RoleBase
{
    private void Start()
    {
        base.InitRoleBase();
        
    }

    private void Update() 
    {
        base.RoleUpDate();
        base.AttackUpDate();
        base.Dead();
    }
    
}
