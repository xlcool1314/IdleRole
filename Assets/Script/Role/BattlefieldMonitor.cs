using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattlefieldMonitor : SingletonMono<BattlefieldMonitor>
{
    public GameObject[] allMyRoles;

    public GameObject[] allEnemys;

    public bool isFirstGame=true;


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

    public GameObject Combination(GameObject go)
    {
        if (allMyRoles.Length >= 3)
        {
            Debug.Log("插入");
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
                Debug.Log("我成功了");
            }
            return null;
        }
        else
        {
            return null;
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
