using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRoleBuilder : SingletonMono<MyRoleBuilder>
{
    
    public GameObject CreatRole(GameObject thisRole)
    {
        var go= Instantiate(thisRole, transform);
        go.tag="MyRolePlane";
        return go;
    }
}
