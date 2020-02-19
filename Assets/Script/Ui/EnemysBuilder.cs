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

    private bool isCreat;

    private async Task LoadSomeConfigs()
    {
        enemysDataName=getLevelDataEnemyNm();
        Debug.Log(enemysDataName);
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
            UserAssetManager.Instance.AddLevel();
            UserAssetManager.Instance.LateUpdateLoop();
            Debug.Log(UserAssetManager.Instance.GetLevel());
            isCreat = true;
        }
    }

    public string getLevelDataEnemyNm()//拿到某个关卡的怪物数据文件名称
    {
        string nm=levelData.levelinfo[UserAssetManager.Instance.GetLevel()].enemysData.ToString();
        return nm;
    }

    private async void Awake()
    {
        isCreat = true;
        await LoadSomeConfigs();
    }

    private void Update()
    {
        if (isCreat == true)
        {
            CreatEnemys(enemysData);
        }
        AllEnemysIsDead();
    }
}
