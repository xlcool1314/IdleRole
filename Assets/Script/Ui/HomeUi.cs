using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class HomeUi : UIBaseBehaviour
{
    public Button shopButton;

    public Button nextLevelButton;

    public bool isOpenNextButton;

    public override void Clean()
    {

    }

    public override void Init()
    {
        shopButton.onClick.AddListener(CreatShopUi);
        //nextLevelButton.onClick.AddListener(GoToNextLevel);
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
        Addressables.InstantiateAsync("ShopUi", transform.parent);
    }
}
