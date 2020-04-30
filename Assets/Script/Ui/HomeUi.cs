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
        Testbutton.onClick.AddListener(TestCreatRole);
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
        gold.text = UserAssetManager.Instance.UpdateGold().ToString();

        if (BattlefieldMonitor.Instance.allMyRoles.Length > 0 && BattlefieldMonitor.Instance.allMyRoles != null)
        {
            SaveMyRole();
        }
    }

    public void CreatShopUi()
    {
        Addressables.InstantiateAsync("ShopUi", transform.parent);
    }

    public void GoToNextLevel()
    {
        UserAssetManager.Instance.AddLevel();
    }

    public void DeleteInfo()
    {
        UserAssetManager.Instance.InitInfo();
    }

    public void SaveMyRole()
    {
        UserAssetManager.Instance.MyAllRoles().Clear();
        BattlefieldMonitor.Instance.FindAllMyRole();
        for (int i = 0; i < BattlefieldMonitor.Instance.allMyRoles.Length; i++)
        {

            UserAssetManager.Instance.MyAllRoles().Add(BattlefieldMonitor.Instance.allMyRoles[i].name);
        }
    }

    public void TestCreatRole()
    {
        MyRoleBuilder.Instance.CreatAllRoles();
    }
}
