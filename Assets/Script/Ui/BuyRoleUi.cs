using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyRoleUi : UIBaseBehaviour
{
    public Button yesButton;
    public Button noButton;

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

    public override void Clean()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }


    public void DetermineBuyRole()
    {
        Clean();
        MyRoleBuilder.Instance.CreatRole(ShopRoleCell.Instance.myRole);
        ShopUi.Instance.CloseShopUi();
        Destroy(gameObject);
    }

    public void CloseBuyRoleUi()
    {
        Clean();
        Destroy(gameObject);
    }
}
