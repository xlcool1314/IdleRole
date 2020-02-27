using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class BattlefieldMonitor : SingletonMono<BattlefieldMonitor>
{
    public GameObject[] allMyRoles;//所有的我方角色

    public GameObject[] allEnemys;//所有的敌方角色

    public bool isFirstGame=true;//是否是第一次开始游戏

    public AllRoleData allRoleData;//所有角色数据

    public GameObject levelRole=null;//进阶角色储存变量

    //等待删除的角色

    public CombinationUi combinationUi;//表现的UI

    public bool isCombination = false;

    void Update()
    {
        FindAllMyRole();
        FindAllEnemys();
        GameOver();     
    
    }

    public void FindAllMyRole()//找到所有的我方角色
    {
        allMyRoles=GameObject.FindGameObjectsWithTag("MyRolePlane");
        
    }

    public void FindAllEnemys()//找到敌方所有角色
    {
        allEnemys=GameObject.FindGameObjectsWithTag("EnemysPlane");
    }


    public void Combination(GameObject go)//判断是否又三个一样的英雄，如果有就合成
    {
        if (allMyRoles.Length >= 3)
        {
            int sameNb;
            sameNb = 0;
            List<GameObject> allDeleteRole = new List<GameObject>();
            for (int i = 0; i < allMyRoles.Length; i++)
            {
                if (allMyRoles[i].name==go.name)
                {
                    sameNb += 1;
                    allDeleteRole.Add(allMyRoles[i]);
                    Debug.Log(allDeleteRole.Count);
                }
            }
            if (sameNb >= 3)
            {
                Addressables.InstantiateAsync("CombinationUi");
                FindLv2Role(go,allDeleteRole);
                //
            }
        }
    }

    public async void FindLv2Role(GameObject go,List<GameObject> goes)//找到要进阶2级的角色是哪一个
    {
        var task = Addressables.LoadAssetAsync<AllRoleData>("AllRoleInfo").Task;
        allRoleData = await task;
        for (int i = 0; i < allRoleData.AllRoleInfo.Count; i++)
        {
            if (go.name == allRoleData.AllRoleInfo[i].name)
            {
                levelRole = allRoleData.AllRoleInfo[i].RoleInfo[1].roleObj;

                MyRoleBuilder.Instance.CreatRole(levelRole);
                InitLv2CombinationUi(go);//初始化合成UI的表现数据
                DeleteCombinationRole(goes);
            }
        }
    }

    public void InitLv2CombinationUi(GameObject go)//初始化进阶UI的数据表现
    {
        combinationUi = GameObject.FindObjectOfType<CombinationUi>();
        combinationUi.betterRole.sprite = levelRole.GetComponent<RoleBase>().mySkin.sprite;
        combinationUi.role01_Skin.sprite=go.GetComponent<RoleBase>().mySkin.sprite;
        combinationUi.role02_Skin.sprite = go.GetComponent<RoleBase>().mySkin.sprite;
        combinationUi.role03_Skin.sprite = go.GetComponent<RoleBase>().mySkin.sprite;
    }

    public void DeleteCombinationRole(List<GameObject> go)
    {
        for (int i = 0; i < go.Count; i++)
        {
            Destroy(go[i]);
        }
    }

    void GameOver()//游戏结束
    {
        if (allMyRoles.Length == 0&&isFirstGame==false)
        {
            SceneManager.LoadScene(0);
        }
    }
}
