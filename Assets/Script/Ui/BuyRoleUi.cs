using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyRoleUi : UIBaseBehaviour
{
    public Button yesButton;
    public Button noButton;

    public ShopRoleCell buyMyRole;

    private void Awake()
    {
        Init();
    }
    
    public override void Init()
    {
        yesButton.onClick.AddListener(DetermineBuyRole);
        noButton.onClick.AddListener(CloseBuyRoleUi);
    }

    public override void UpdateInfo(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public override void Clean()//清除所有的监听
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }


    public void DetermineBuyRole()//确定购买我的角色
    {
        Clean();
        MyRoleBuilder.Instance.CreatRole(ShopRoleCell.Instance.myRole);
        BattlefieldMonitor.Instance.FindAllMyRole();
        BattlefieldMonitor.Instance.isFirstGame = false;
        ShopUi.Instance.CloseShopUi();
        Destroy(gameObject);
    }

    public void CloseBuyRoleUi()//关闭购买UI
    {
        Clean();
        Destroy(gameObject);
    }
}
