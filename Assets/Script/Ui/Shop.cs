using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;


public class Shop : SingletonMono<Shop>
{
    public MyRoleData rolesData;

    public GameObject roleCell;

    private async Task LoadSomeConfigs()
    {
        var task = Addressables.LoadAssetAsync<MyRoleData>("MyRoleData").Task;
        rolesData = await task;
    }

    public void CreatAllShopRoles()
    {
        if (rolesData.myRoles != null)
        {
            for (int i = 0; i < rolesData.myRoles.Count; i++)
            {
                var go = rolesData.myRoles[i];
                if (go.isUnlock==true)
                {
                    Addressables.InstantiateAsync("ShopRoleCell", transform);
                    go.howMuchMoney = 1000;

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
