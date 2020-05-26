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
        CreatAllRoles();
    }

    public GameObject CreatRole(GameObject thisRole)
    {
        var go = Instantiate(thisRole, transform);
        go.tag = "MyRolePlane";
        go.name = thisRole.name;
        go.GetComponent<RoleBase>().myAnimator.SetTrigger("appear");
        return go;
    }
    public async Task CreatAllRoles()
    {
        for (int i = 0; i < UserAssetManager.Instance.CreatRoleSta().Count; i++)
        {
                var go = await Addressables.InstantiateAsync(UserAssetManager.Instance.CreatRoleSta()[i]._name,transform).Task;
                go.tag = "MyRolePlane";
                go.name = UserAssetManager.Instance.CreatRoleSta()[i]._name;
                go.GetComponent<RoleBase>().lv = UserAssetManager.Instance.CreatRoleSta()[i]._lv;
            Debug.Log(go);
        }
    }
}
