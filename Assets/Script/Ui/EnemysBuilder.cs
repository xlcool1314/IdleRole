using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemysBuilder : MonoBehaviour
{
    public EnemysData enemysData;

    public string enemysDataName;

    private bool isCreat;

    private async Task LoadSomeConfigs()
    {
        var task = Addressables.LoadAssetAsync<EnemysData>(enemysDataName).Task;
        enemysData = await task;
    }

    public void CreatEnemys(EnemysData enemyData)
    {
        if (enemyData != null&&isCreat==true)
        {
            for (int i = 0; i < enemyData.enemys.Count; i++)
            {
               var go= Instantiate(enemyData.enemys[i].enemy, transform);
               go.tag="EnemysPlane";
            }
            isCreat = false;
        }
        
    }

    void AllEnemysIsDead()
    {
        if (BattlefieldMonitor.Instance.allEnemys.Length <= 0)
        {
            isCreat = true;
        }
    }

    private async void Awake()
    {
        isCreat = true;
        enemysDataName = "EnemysData001";
        await LoadSomeConfigs();
    }

    private void Update()
    {
        AllEnemysIsDead();
        if (isCreat == true)
        {
            CreatEnemys(enemysData);
        }
    }
}
