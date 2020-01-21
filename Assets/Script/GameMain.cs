using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameMain : SingletonMono<GameMain>
{
    private async void Awake()
    {
       await Oda();
    }
    public async Task Oda()
    {
        var go = await Addressables.InstantiateAsync("LogoUi", transform).Task;
    }
}
