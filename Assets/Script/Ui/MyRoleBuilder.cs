using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using Sirenix.OdinInspector;

public class MyRoleBuilder : SingletonMono<MyRoleBuilder>
{

    private void Start()
    {
        //CreatAllRoles();
    }

    public GameObject CreatRole(GameObject thisRole)
    {
        var go = Instantiate(thisRole, transform);
        go.tag = "MyRolePlane";
        go.name = thisRole.name;
        return go;
    }

    [Button]
    public async Task CreatAllRoles()
    {
        UserAsset asset = new UserAsset();
        for (int i = 0; i < asset.SaveRoleStatus.Count; i++)
        {
                var go = await Addressables.InstantiateAsync(asset.SaveRoleStatus[i]._name).Task;
                go.tag = "MyRolePlane";
                go.name = asset.SaveRoleStatus[i]._name;
                go.GetComponent<RoleBase>().lv = asset.SaveRoleStatus[i]._lv;
        }
    }
}
