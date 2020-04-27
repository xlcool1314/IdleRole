using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using TMPro;

public class HomeUi : UIBaseBehaviour
{
    public Button shopButton;

    public Button nextLevelButton;

    public bool isOpenNextButton;

    public TextMeshProUGUI gold;

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

    private void Update()
    {
        gold.text = UserAssetManager.Instance.UpdateGold().ToString();
    }

    public void CreatShopUi()
    {
        Addressables.InstantiateAsync("ShopUi", transform.parent);
    }
}
