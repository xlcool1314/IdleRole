using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemysBuilder : MonoBehaviour
{
    public EnemysData enemysData;

    public LevelData levelData;

    public string enemysDataName;

    private bool isCreat=true;

    private async Task LoadSomeConfigs()
    {
        enemysDataName=GetLevelDataEnemyNm();
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
        else
        {
            return;
        }
        
        
    }

    void AllEnemysIsDead()
    {
        if (BattlefieldMonitor.Instance.allEnemys.Length <= 0&&isCreat==false)
        {
            isCreat = true;
        }
    }

    public string GetLevelDataEnemyNm()//拿到某个关卡的怪物数据文件名称
    {
        string nm=levelData.levelinfo[UserAssetManager.Instance.GetLevel()].enemysData.ToString();
        Debug.Log(nm);
        return nm;
    }

    private async void Awake()
    {
        await LoadSomeConfigs();
    }

    private async void Update()
    {
        AllEnemysIsDead();
        if (isCreat)
        {
            await LoadSomeConfigs();
            CreatEnemys(enemysData);
        }

    }
}
