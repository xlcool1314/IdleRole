using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Create AllRoleData")]
public class AllRoleData : ScriptableObject
{
    public List<RoleData> AllRoleInfo;//所有角色信息

}

[System.Serializable]
public class RoleData
{
    public string name;
    public List<RoleInfo> RoleInfo;//某个角色信息
}

[System.Serializable]
public class RoleInfo
{
    public string name;//怪物名称

    public string describe;//描述

    public GameObject roleObj;//怪物预制体

}
