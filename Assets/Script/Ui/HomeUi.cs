using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUi : UIBaseBehaviour
{
    public Button shopButton;

    public override void Clean()
    {
        throw new System.NotImplementedException();
    }

    public override void Init()
    {
        shopButton.onClick.AddListener(CreatShopUi);
    }

    public override void UpdateInfo(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void CreatShopUi()
    {

    }
}
