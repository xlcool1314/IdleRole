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

    }

    // Update is called once per frame
    void Update()
    {
        level.text = UserAssetManager.Instance.GetLevel().ToString();

        countDown.text = enemysBuilder.creatEnemysTimes.ToString("f0");
    }
}
