using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameMain : SingletonMono<GameMain>
{
    private async void Awake()
    {
       await ResourcesManager.Instance.InitResources();
        Debug.Log(ResourcesManager.Instance.shopRoleCell);

       Application.targetFrameRate = 60;

       await UserAssetManager.Instance.Init();
       
       await GameInit();
    }

    private async Task GameInit()
    {
       await Addressables.InstantiateAsync("LogoUi", transform).Task;
    }

    private void Update()
    {
        UserAssetManager.Instance.LateUpdateLoop();
    }
}
