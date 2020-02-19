using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class ShopRoleCell : SingletonMono<ShopRoleCell>
{
    public Button myButton;

    public GameObject myRole;

    public void ShopRoleCellInit()
    {

        myButton = this.transform.GetComponent<Button>();
        myButton.onClick.AddListener(CreatBuyRoleUi);
    }

    private void Start()
    {
        ShopRoleCellInit();
    }

    public void CreatBuyRoleUi()//创建确定购买的UI
    {
        ShopRoleCell.Instance.myRole=this.myRole;
        Addressables.InstantiateAsync("BuyRoleUi");
    }
}
