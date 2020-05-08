using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMan : RoleBase
{
    private void Start()
    {
        base.InitRoleBase();
    }

    private void Update() 
    {
        base.RoleUpDate();
        base.TreatmentUpDate();
        base.Dead();
    }
    
}
