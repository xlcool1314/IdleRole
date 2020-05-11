using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

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

    public async Task CreatAllRoles()
    {
        UserAsset asset = new UserAsset();
        for (int i = 0; i < asset.SaveRoleStatus.Count; i++)
        {
            foreach (var item in asset.SaveRoleStatus[i])
            {
                var go = await Addressables.InstantiateAsync(item.Key).Task;
                go.tag = "MyRolePlane";
                go.name = item.Value._name;
            }
        }
    }
}
