using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemysBuilder : MonoBehaviour
{
    public EnemysData enemysData;

    public string enemysDataName;

    private async Task LoadSomeConfigs()
    {
        var task = Addressables.LoadAssetAsync<EnemysData>(enemysDataName).Task;
        enemysData = await task;
    }

    public void CreatEnemys(EnemysData enemyData)
    {
        if (enemyData != null)
        {
            for (int i = 0; i < enemyData.enemys.Count; i++)
            {
                Instantiate(enemyData.enemys[i].enemy, transform);
            }
        }
        
    }

    private async void Awake()
    {
        enemysDataName = "EnemysData001";
        await LoadSomeConfigs();
        CreatEnemys(enemysData);
    }
}
