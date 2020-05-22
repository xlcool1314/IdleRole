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




    public async Task InitResources()
    {
         var task001 = Addressables.LoadAssetAsync<GameObject>("ShopRoleCell").Task;
        shopRoleCell = await task001;

        var task002 = Addressables.LoadAssetAsync<GameObject>("ShopRoleCell").Task;
        combinationUi = await task002;

        var task003 = Addressables.LoadAssetAsync<GameObject>("ShopRoleCell").Task;
        buyRoleUi = await task003;

        var task004 = Addressables.LoadAssetAsync<GameObject>("ShopRoleCell").Task;
        logoUi = await task004;

        var task005 = Addressables.LoadAssetAsync<GameObject>("ShopRoleCell").Task;
        gameOverUi = await task005;

        var task006 = Addressables.LoadAssetAsync<GameObject>("ShopRoleCell").Task;
        shopUi = await task006;



    }




}
