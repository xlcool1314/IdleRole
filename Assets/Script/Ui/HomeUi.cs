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

    public Button button;

    public Button Testbutton;

    public bool isOpenNextButton;

    public TextMeshProUGUI gold;

    public override void Clean()
    {

    }

    public override void Init()
    {
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
    }

    private void Update()
    {
        UpDateGoldShow();
    }

    public void UpDateGoldShow()//更新显示金币数量
    {
        gold.text = UserAssetManager.Instance.GetGold().ToString();
    }

    public void CreatShopUi()
    {
        Addressables.InstantiateAsync("ShopUi", transform.parent);
    }

    public void GoToNextLevel()
    {
        UserAssetManager.Instance.AddLevel();
        UserAssetManager.Instance.SaveRoleSta();
    }

    public void DeleteInfo()
    {
        UserAssetManager.Instance.InitInfo();
    }
}
