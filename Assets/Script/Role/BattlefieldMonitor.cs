using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattlefieldMonitor : SingletonMono<BattlefieldMonitor>
{
    public GameObject[] allMyRoles;

    public GameObject[] allEnemys;

    
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

    void GameOver()//游戏结束
    {
        if (allMyRoles.Length == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
