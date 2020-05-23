using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameMain : SingletonMono<GameMain>
{
    private async void Awake()
    {
       Application.targetFrameRate = 60;

       await UserAssetManager.Instance.Init();
       
       await GameInit();

        await ResourcesManager.Instance.InitResources();
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
