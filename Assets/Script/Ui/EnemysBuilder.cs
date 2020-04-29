using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class EnemysBuilder : MonoBehaviour
{
    public EnemysData enemysData;//怪物的数据

    public LevelData levelData;//关卡数据

    public string enemysDataName;

    public Sprite  enemyHpBar;

    private bool isCreat=true;

    private async Task LoadSomeConfigs()
    {
        var taskHpBar = Addressables.LoadAssetAsync<Sprite>("hpred").Task;
        enemyHpBar = await taskHpBar;
        enemysDataName=GetLevelDataEnemyNm();
        var task = Addressables.LoadAssetAsync<EnemysData>(enemysDataName).Task;
        enemysData = await task;
    }

    public void CreatEnemys(EnemysData enemyData)//刷新怪物
    {
        if (enemyData != null&&isCreat==true)
        {
            for (int i = 0; i < enemyData.enemys.Count; i++)
            {
               var go= Instantiate(enemyData.enemys[i].enemy, transform);
               go.tag="EnemysPlane";
               go.GetComponent<RoleBase>().myHpBarImage.sprite = enemyHpBar;
               
            }
            isCreat = false;
        }
        else
        {
            return;
        }
    }

    void AllEnemysIsDead()//所有这轮的怪物全部死亡，生成新的一批怪物
    {
        if (BattlefieldMonitor.Instance.allEnemys.Length <= 0&&isCreat==false)
        {
            isCreat = true;
        }
    }

    public string GetLevelDataEnemyNm()//拿到某个关卡的怪物数据文件名称
    {
        string nm=levelData.levelinfo[UserAssetManager.Instance.GetLevel()-1].enemysData.ToString();
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
