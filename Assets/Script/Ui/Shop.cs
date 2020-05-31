using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using TMPro;
using UnityEngine.UI;


public class Shop : SingletonMono<Shop>
{
    public MyRoleData rolesData;

    public AllRoleData allRoleData;

    public TextMeshProUGUI howMuchRoleMoney;

    
    private async Task LoadSomeConfigs()//拿到商店展示的英雄列表
    {
        var task = Addressables.LoadAssetAsync<MyRoleData>("MyRoleData").Task;
        rolesData = await task;

        var task01 = Addressables.LoadAssetAsync<AllRoleData>("AllRoleInfo").Task;
        allRoleData = await task01;

    }

    public async void CreatAllShopRoles()//生成商店的角色以及数据同步
    {
        if (rolesData.myRoles != null)
        {
            for (int i = 0; i < rolesData.myRoles.Count; i++)
            {
                var go = rolesData.myRoles[i];
                if (go.isUnlock==true&& allRoleData.roles.ContainsKey(go.myRole.name))
                {
                  var go2= await Addressables.InstantiateAsync("ShopRoleCell", transform).Task;
                    go2.GetComponent<ShopRoleCell>().myRole=go.myRole;
                    go2.GetComponent<ShopRoleCell>().nameText.text = go.myRole.name;
                    go2.GetComponent<ShopRoleCell>().moneyText.text = allRoleData.roles[go.myRole.name].howMuchMoneys.ToString();
                    go2.GetComponent<ShopRoleCell>().skin.sprite = allRoleData.roles[go.myRole.name].mySkin;
                    go2.GetComponent<ShopRoleCell>().skin.SetNativeSize();
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
