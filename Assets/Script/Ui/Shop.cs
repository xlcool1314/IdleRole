using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using TMPro;


public class Shop : SingletonMono<Shop>
{
    public MyRoleData rolesData;


    public TextMeshProUGUI howMuchRoleMoney;

    
    private async Task LoadSomeConfigs()
    {
        var task = Addressables.LoadAssetAsync<MyRoleData>("MyRoleData").Task;
        rolesData = await task;
        Debug.Log(rolesData.myRoles.Count);
    }

    public async void CreatAllShopRoles()
    {
        if (rolesData.myRoles != null)
        {
            for (int i = 0; i < rolesData.myRoles.Count; i++)
            {
                var go = rolesData.myRoles[i];
                if (go.isUnlock==true)
                {
                  var go2= await Addressables.InstantiateAsync("ShopRoleCell", transform).Task;
                  go2.GetComponent<ShopRoleCell>().myRole=go.myRole;
                }
                
            }
        }
    }

    private async void Start()
    {
        await LoadSomeConfigs();
        CreatAllShopRoles();
    }

}
