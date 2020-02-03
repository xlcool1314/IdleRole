using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemysBuilder : MonoBehaviour
{
    public EnemysData enemysData;

    public GameObject[] enemysgameObjects;

    private async Task LoadSomeConfigs()
    {
        var task = Addressables.LoadAssetAsync<EnemysData>("EnemysData001").Task;
        enemysData = await task;
        Debug.Log(enemysData.enemys.Count);
    }

    public void CreatEnemys()
    {
        if (enemysData != null)
        {
            for (int i = 0; i < enemysData.enemys.Count; i++)
            {
                enemysgameObjects[i] = enemysData.enemys[i].enemy;
                Instantiate(enemysgameObjects[i], transform.parent);
            }
        }
        
    }

    private async void Awake()
    {
        await LoadSomeConfigs();
        CreatEnemys();
    }
}
