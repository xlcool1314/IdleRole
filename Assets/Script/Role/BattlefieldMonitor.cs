using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldMonitor : SingletonMono<BattlefieldMonitor>
{
    public GameObject[] allMyRoles;

    public GameObject[] allEnemys;

    
    void Update()
    {
        FindAllMyRole();
    }

    public void FindAllMyRole()
    {
        allMyRoles=GameObject.FindGameObjectsWithTag("MyRolePlane");
    }
}
