using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightUi : UIBaseBehaviour
{
    public EnemysBuilder enemysBuilder;

    public TextMeshProUGUI countDown;

    public TextMeshProUGUI level;

    public override void Clean()
    {
        throw new System.NotImplementedException();
    }

    public override void Init()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateInfo(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        countDown.gameObject.SetActive(false);
    }


    private void FixedUpdate()
    {
        level.text = UserAssetManager.Instance.GetLevel().ToString();
        if (enemysBuilder.creatEnemysTimes >= 3)
        {
            countDown.gameObject.SetActive(false);
        }
        else if (enemysBuilder.creatEnemysTimes < 3 && enemysBuilder.creatEnemysTimes >= 0)
        {
            countDown.gameObject.SetActive(true);
        }
        countDown.text = enemysBuilder.creatEnemysTimes.ToString("f0");
    }
}

