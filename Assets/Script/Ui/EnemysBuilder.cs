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

    public float creatEnemysTimes =3f;

    private async Task LoadSomeConfigs()
    {
        var taskHpBar = Addressables.LoadAssetAsync<Sprite>("hpred").Task;
        enemyHpBar = await taskHpBar;
        enemysDataName=GetLevelDataEnemyNm();
        var task = Addressables.LoadAssetAsync<EnemysData>(enemysDataName).Task;
        enemysData = await task;
    }

    void AllEnemysIsDead()//所有这轮的怪物全部死亡，生成新的一批怪物
    {
        BattlefieldMonitor.Instance.FindAllEnemys();
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

    public IEnumerator CreatEnemys(EnemysData enemyData)//攻击频率
    {
           creatEnemysTimes -= Time.deltaTime;
            yield return new WaitForSeconds(3);
            if (enemyData != null && isCreat == true)
            {
                creatEnemysTimes = 3;
                for (int i = 0; i < enemyData.enemys.Count; i++)
                {
                    var go = Instantiate(enemyData.enemys[i].enemy, transform);
                    go.tag = "EnemysPlane";
                    go.GetComponent<RoleBase>().myHpBarImage.sprite = enemyHpBar;
                    go.GetComponent<RoleBase>().RoleInitInfo();
                }
                isCreat = false;
            UserAssetManager.Instance.NoFirstGame();
            }
            else
            {
            yield break;
            }
        
    }

    private async void Update()
    {
        AllEnemysIsDead();
        if (isCreat)
        {
            await LoadSomeConfigs();
            StartCoroutine(CreatEnemys( enemysData));
        }
    }
}
