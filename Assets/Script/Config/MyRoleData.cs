using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Create MyRoleData ")]
public class MyRoleData : ScriptableObject
{
    public List<MyRole> myRoles;
    
}

[System.Serializable]
public class MyRole
{
    public bool isUnlock;

    public GameObject myRole;

    public int howMuchMoney;
    
}

