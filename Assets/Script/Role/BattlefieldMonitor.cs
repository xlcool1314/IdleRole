using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class BattlefieldMonitor : SingletonMono<BattlefieldMonitor>
{
    public GameObject[] allMyRoles;

    public GameObject[] allEnemys;

    public bool isFirstGame=true;

    public AllRoleData allRoleData;

    public GameObject levelRole;

    public CombinationUi combinationUi;

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

    public GameObject Combination(GameObject go)//判断是否又三个一样的英雄，如果又就合成
    {
        if (allMyRoles.Length >= 3)
        {
            int sameNb;
            sameNb = 0;
            for (int i = 0; i < allMyRoles.Length; i++)
            {
                bool isSame = allMyRoles[i].gameObject.name.Equals(go.name);
                Debug.Log(isSame);
                if (isSame)
                {
                    sameNb += 1;
                }
            }
            if (sameNb >= 3)
            {
                Addressables.InstantiateAsync("CombinationUi");
                FindLv2Role(go);
                
            }
            return null;
        }
        else
        {
            return null;
        }
        
    }

    public async void FindLv2Role(GameObject go)
    {
        var task = Addressables.LoadAssetAsync<AllRoleData>("AllRoleInfo").Task;
        allRoleData = await task;
        for (int i = 0; i < allRoleData.AllRoleInfo.Count; i++)
        {
            if (go.name == allRoleData.AllRoleInfo[i].name)
            {
                levelRole = allRoleData.AllRoleInfo[i].RoleInfo[1].roleObj;

                InitLv2CombinationUi(go);
                Debug.Log(levelRole);
            }
        }
    }

    public void InitLv2CombinationUi(GameObject go)
    {
        combinationUi = GameObject.FindObjectOfType<CombinationUi>();
        combinationUi.betterRole.sprite = levelRole.GetComponent<RoleBase>().mySkin.sprite;
        combinationUi.role01_Skin.sprite=go.GetComponent<RoleBase>().mySkin.sprite;
        combinationUi.role02_Skin.sprite = go.GetComponent<RoleBase>().mySkin.sprite;
        combinationUi.role03_Skin.sprite = go.GetComponent<RoleBase>().mySkin.sprite;
    }

    void GameOver()//游戏结束
    {
        if (allMyRoles.Length == 0&&isFirstGame==false)
        {
            SceneManager.LoadScene(0);
        }
    }
}
