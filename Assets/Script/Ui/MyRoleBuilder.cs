using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class MyRoleBuilder : SingletonMono<MyRoleBuilder>
{

    public GameObject roles;

    private void Start()
    {
        CreatAllRoles();
    }

    public GameObject CreatRole(GameObject thisRole)
    {
        var go= Instantiate(thisRole, transform);
        go.tag="MyRolePlane";
        go.name = thisRole.name;
        return go;
    }

    public async Task CreatAllRoles()
    {
        if (UserAssetManager.Instance.BoolRoles())
        {
            for (int i = 0; i < UserAssetManager.Instance.MyAllRoles().Count; i++)
            {
              var go= Addressables.LoadAssetAsync<GameObject>(UserAssetManager.Instance.MyAllRoles()[i]).Task;
              roles = await go;
              var go1= Instantiate(roles, transform);
                go1.tag= "MyRolePlane";
                go1.name = UserAssetManager.Instance.MyAllRoles()[i];
            }
        }
    }
}
