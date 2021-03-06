﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using TMPro;

public class HomeUi : UIBaseBehaviour
{
    public Button shopButton;

    public Button nextLevelButton;

    public Button button;

    public Button Testbutton;

    public bool isOpenNextButton;

    public TextMeshProUGUI gold;


    public TextMeshProUGUI m_ClockText;
    private float m_Timer;
    private int m_Hour;//时
    private int m_Minute;//分
    private int m_Second;//秒
    public void Clock()//计时器
    {
        m_Timer += Time.deltaTime;
        m_Second = (int)m_Timer;
        if (m_Second > 59.0f)
        {
            m_Second = (int)(m_Timer - (m_Minute * 60));
        }
        m_Minute = (int)(m_Timer / 60);
        if (m_Minute > 59.0f)
        {
            m_Minute = (int)(m_Minute - (m_Hour * 60));
        }
        m_Hour = m_Minute / 60;
        if (m_Hour >= 24.0f)
        {
            m_Timer = 0;
        }
        m_ClockText.text = string.Format("{0:d2}:{1:d2}:{2:d2}", m_Hour, m_Minute, m_Second);
    }

    public override void Init()
    {
        m_Timer = UserAssetManager.Instance.GetTime();
        button.onClick.AddListener(DeleteInfo);
        shopButton.onClick.AddListener(CreatShopUi);
        nextLevelButton.onClick.AddListener(GoToNextLevel);
    }

    public override void UpdateInfo(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        InvokeRepeating("TimerInterval", 5f, 10f);
    }

    private void Update()
    {
        Clock();
        gold.text = UserAssetManager.Instance.GetGold().ToString();
    }

    public void CreatShopUi()
    {
        Addressables.InstantiateAsync("ShopUi", transform.parent);
    }

    public void GoToNextLevel()
    {
        if (UserAssetManager.Instance.GetMyOpenNextLevelBool() == true)
        {
            UserAssetManager.Instance.AddLevel();
            BattlefieldMonitor.Instance.FindAllEnemys();
            for (int i = 0; i < BattlefieldMonitor.Instance.allEnemys.Length; i++)
            {
                Destroy(BattlefieldMonitor.Instance.allEnemys[i].gameObject, 0.5f);
            }
            UserAssetManager.Instance.NoOpenNextLevel();//锁门
            Addressables.InstantiateAsync("PassUi");
        }
        else
        {
            Debug.Log("门锁了");
        }
    }

    public void DeleteInfo()
    {
        UserAssetManager.Instance.InitInfo();
    }

    public void TimerInterval()//储存计时器间隔
    {
            UserAssetManager.Instance.SaveTime(m_Timer);

    }

    public override void Clean()
    {
        throw new System.NotImplementedException();
    }
}
