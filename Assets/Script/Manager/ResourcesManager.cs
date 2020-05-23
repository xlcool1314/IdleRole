using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ResourcesManager : SingletonMono<ResourcesManager>
{
    public GameObject shopRoleCell;

    public GameObject combinationUi;

    public GameObject buyRoleUi;

    public GameObject logoUi;

    public GameObject gameOverUi;

    public GameObject shopUi;

    public GameObject mushroom;

    public GameObject roleInfo;




    public async Task InitResources()
    {
         var task001 = Addressables.LoadAssetAsync<GameObject>("ShopRoleCell").Task;
        shopRoleCell = await task001;

        var task002 = Addressables.LoadAssetAsync<GameObject>("CombinationUi").Task;
        combinationUi = await task002;

        var task003 = Addressables.LoadAssetAsync<GameObject>("BuyRoleUi").Task;
        buyRoleUi = await task003;

        var task004 = Addressables.LoadAssetAsync<GameObject>("LogoUi").Task;
        logoUi = await task004;

        var task005 = Addressables.LoadAssetAsync<GameObject>("GameOverUi").Task;
        gameOverUi = await task005;

        var task006 = Addressables.LoadAssetAsync<GameObject>("ShopUi").Task;
        shopUi = await task006;

        var task007 = Addressables.LoadAssetAsync<GameObject>("RoleInfo").Task;
        roleInfo = await task007;

        Debug.Log(roleInfo);



    }




}
